using Project_D.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;


namespace Project_D.ViewModels
{
    internal class StorageMainViewModel : NotificationBase
    {
        public StorageMainViewModel()
        {
            _storageModel = new StorageModel();
            _sortModel = new SortModel();
            Storages.Add(new StorageViewModel
            {
                Name = "HHHHHHHHH",
                //Path = "FFFFFFFFFFFFFF"
            });

            foreach (var s in _sortModel.GetSorts())
            {
                Sorts.Add(new SortViewModel
                {
                    Direction = s.Direction,
                    Content = s.Text,
                    Kind = s.Kind,
                });
            }
        }

        private StorageModel _storageModel;
        private SortModel _sortModel;

        public ObservableCollection<StorageViewModel> Storages { get; } = new ObservableCollection<StorageViewModel>();
        public ObservableCollection<SortViewModel> Sorts { get; } = new ObservableCollection<SortViewModel>();

        public void AddStorage(string name, string path, BitmapImage image, string extension, StorageItemTypes storageType)
        {
            StorageViewModel storage = new StorageViewModel
            {
                Name = name,
                Path = path,
                Thumbnail = image,
                Extension = extension,
                StorageType = storageType,
            };
            Storages.Add(storage);
            _storageModel.AddStorage(storage);
        }

        public void RemoveStorages(IEnumerable<object> items)
        {
            foreach (var item in items)
            {
                if (item is StorageViewModel storage)
                {
                    Storages.Remove(storage);
                    _storageModel.RemoveStorage(storage);
                }
            }
        }

        public void SortStorage(object sortItem)
        {
            var sort = sortItem as SortViewModel;
            if (sort is null) return;

            switch (sort.Kind)
            {
                case Kind.Extension:
                    Storages.Sort(new ExtensionComparer());
                    break;
                case Kind.Name:
                    Storages.Sort(new NameComparer());
                    break;
            }
        }

        public async void RenameStorage(object item)
        {
            if (item is StorageViewModel storage)
            {
                var file = await StorageFile.GetFileFromPathAsync(storage.Path);
                await file.RenameAsync(storage.Name);
            }
        }
    }
}
