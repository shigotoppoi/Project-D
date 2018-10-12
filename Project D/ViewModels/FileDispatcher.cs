using Project_D.Datas;
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
    internal class FileDispatcher : IProgressViewModel
    {
        public FileDispatcher(IEnumerable<Storage> storages, Rule rule)
        {
            _ruleParser = new RuleParser();
            _rule = rule;
            _storages = storages;
        }

        private RuleParser _ruleParser;
        private Rule _rule;
        private IEnumerable<Storage> _storages;
        public double Value { get; private set; }

        public async void Run()
        {
            var formatKeys = _ruleParser.ParseFormat(_rule.Format);
            var desRootFolder = await StorageFolder.GetFolderFromPathAsync(_rule.Destination);
            foreach (var storage in _storages)
            {
                var desFolderName = _ruleParser.ParseName(formatKeys, storage.Name);

                var desSubFolder = await _searchFolderAsync(desRootFolder, desFolderName);

                if (desSubFolder is null && _rule.CreateIfNew)
                {
                    desSubFolder = await desRootFolder.CreateFolderAsync(desFolderName);
                }
                else if (desSubFolder is null && !_rule.CreateIfNew)
                {
                    //todo save info
                    continue;
                }

                if (storage.IsFile)
                {
                    var souStorageFile = await StorageFile.GetFileFromPathAsync(storage.Path);
                    await souStorageFile.MoveAsync(desSubFolder);
                }
                else
                {
                    var folder = await _searchFolderAsync(desSubFolder, storage.Name);
                    if (folder is null)
                    {
                        folder = await desSubFolder.CreateFolderAsync(storage.Name);
                    }

                    var souFolder = await StorageFolder.GetFolderFromPathAsync(storage.Path);
                    var items = await souFolder.GetItemsAsync();

                }
            }
        }

        private async Task<StorageFolder> _searchFolderAsync(StorageFolder root, string name)
        {
            var items = await root.GetItemsAsync();
            var item = items.FirstOrDefault(f => f.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (item is StorageFile)
            {
                //
            }
            return item as StorageFolder;
        }

        private async void _moveFiles(StorageFolder source, StorageFolder destination, string fullName, bool replaceIfExists, bool creatIfNew)
        {
            var souItems = await source.GetItemsAsync();
            var desItems = await destination.GetItemsAsync();
            foreach (var souItem in souItems)
            {
                //沒有目標
                if (!souItem.Name.Equals(fullName)) continue;

                var desItem= desItems.FirstOrDefault(i => i.Name.Equals(souItem.Name));


                if (souItem is StorageFile soucefile)
                {
                    if (desItem is StorageFile && replaceIfExists)
                    {
                        await soucefile.MoveAndReplaceAsync(desItem as StorageFile);
                    }
                    else if(desItem is StorageFolder && replaceIfExists)
                    {
                        await desItem.DeleteAsync();
                        await soucefile.MoveAsync(destination);
                    }
                    else
                    {
                        await soucefile.MoveAsync(destination);
                    }
                }
                else if (souItem is StorageFolder folder)
                {
                    
                }
            }
        }
    }
}
