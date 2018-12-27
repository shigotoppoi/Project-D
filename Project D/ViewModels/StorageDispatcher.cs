﻿using Project_D.Datas;
using Project_D.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Project_D.ViewModels
{
    public class StorageDispatcher : IProgressViewModel
    {
        public StorageDispatcher(IEnumerable<StorageViewModel> storages, Rule rule)
        {
            _ruleParser = new RuleParser();
            _rule = rule;
            _storages = storages;
            Maximum = storages.Count();
            Minimum = 0;
            SuspendComman = new RelayCommand(_suspend);
        }

        private RuleParser _ruleParser;
        private Rule _rule;
        private IEnumerable<StorageViewModel> _storages;
        private bool _isSuspended;

        public double Value { get; private set; } = 0;
        public double Maximum { get; }
        public double Minimum { get; }
        public RelayCommand SuspendComman { get; }
        public object Result { get; private set; }

        public async Task RunAsync()
        {
            List<OutcomeViewModel> results = new List<OutcomeViewModel>();
            var formatKeys = _ruleParser.ParseFormat(_rule.Format);
            var desRootFolder = await StorageFolder.GetFolderFromPathAsync(_rule.Destination);
            var desItems = await desRootFolder.GetItemsAsync();
            foreach (var storage in _storages)
            {
                if (_isSuspended) break;

                var desFolderName = _ruleParser.ParseName(formatKeys, storage.Name);
                var desFolder = await desRootFolder.TryGetItemAsync(desFolderName) as StorageFolder;

                if (desFolder == null && _rule.CreateIfNone)
                {
                    results.Add(new OutcomeViewModel { Category = OutcomeCategory.NewFolder, Storage = storage });
                }
                else if (desFolder == null)
                {
                    results.Add(new OutcomeViewModel { Category = OutcomeCategory.FolderNotFound, Storage = storage });
                    continue;
                }

                IStorageItem item = null;
                try
                {
                    if (storage.StorageType == StorageItemTypes.File)
                    {
                        item = await StorageFile.GetFileFromPathAsync(storage.Path);
                    }
                    else
                    {
                        item = await StorageFolder.GetFolderFromPathAsync(storage.Path);
                    }
                }
                catch (Exception ex)
                {
                    switch (ex)
                    {
                        case FileNotFoundException file:
                        case DirectoryNotFoundException folder:
                            results.Add(new OutcomeViewModel { Category = OutcomeCategory.MissingSource, Storage = storage });
                            continue;
                        default:
                            throw;
                    }
                }

                await _moveFiles(item, desFolder, _rule.ReplaceIfExist);
                Value++;
                results.Add(new OutcomeViewModel { Category = OutcomeCategory.Success, Storage = storage });
            }

            Result = results;
        }

        private async Task _moveFiles(IStorageItem souItem, StorageFolder destination, bool replaceIfExists)
        {
            var desItem = await destination.TryGetItemAsync(souItem.Name);

            if (souItem is StorageFile souFile)
            {
                if (desItem != null && replaceIfExists)
                {
                    await souFile.MoveAndReplaceAsync(desItem as StorageFile);
                }
                else if (desItem == null)
                {
                    await souFile.MoveAsync(destination);
                }
                else
                {
                    return;
                }
            }
            else if (souItem is StorageFolder souFolder)
            {
                StorageFolder subDesFolder;
                if (desItem != null && replaceIfExists)  //
                {
                    await desItem.DeleteAsync();
                    subDesFolder = await destination.CreateFolderAsync(souFolder.DisplayName);
                }
                else if (desItem != null)
                {
                    subDesFolder = desItem as StorageFolder;
                }
                else if (desItem == null)
                {
                    subDesFolder = await destination.CreateFolderAsync(souFolder.DisplayName);
                }
                else
                {
                    return;
                }

                foreach (var item in await souFolder.GetItemsAsync())
                {
                    await _moveFiles(souFolder, subDesFolder, replaceIfExists);
                }
                await souFolder.DeleteAsync();
            }
            else
            {
                //todo
            }
        }

        public override string ToString()
        {
            var total = Maximum.ToString();
            var current = Value.ToString();
            return $"{current.PadLeft(total.Length, ' ')} / {total}";
        }

        private void _suspend()
        {
            _isSuspended = true;
        }
    }
}
