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
            _storageMainModel = new StorageMainModel();
            _sortedKindModel = new SortedKindModel();


            Storages.Add(new StorageViewModel
            {
                Name = "HHHHHHHHH",
                //Path = "FFFFFFFFFFFFFF"
            });

            foreach (var s in _sortedKindModel.GetSortedTypes())
            {
                SortedKinds.Add(new SortedKindViewModel(s));
            }
        }

        private StorageMainModel _storageMainModel;
        private SortedKindModel _sortedKindModel;
        private ObservableCollection<StorageViewModel> _Storages = new ObservableCollection<StorageViewModel>();
        public ObservableCollection<StorageViewModel> Storages => _Storages;
        public ObservableCollection<SortedKindViewModel> SortedKinds = new ObservableCollection<SortedKindViewModel>();

        public void AddStorage(string name, string path, BitmapImage image, string extension, bool isFile)
        {
            StorageViewModel storage = new StorageViewModel
            {
                Name = name,
                //Path = path,
                Thumbnail = image,
                Extension = extension,
                IsFile = isFile
            };
            _storageMainModel.AddStorage(storage);
            _Storages.Add(storage);
        }

        public void AddStorage(IStorageItem storage)
        {

        }

        public void RemoveStorages(IEnumerable<object> items)
        {
            foreach (var item in items)
            {
                if (item is StorageViewModel storage)
                {
                    _storageMainModel.RemoveStorage(storage);
                    _Storages.Remove(storage);
                }
            }
        }

        public void SortStorage(object item)
        {
            var sortedKind = item as SortedKindViewModel;
            if (sortedKind is null) return;

            switch (sortedKind.Kind)
            {
                case Datas.Kind.Extension:
                    Storages.Sort(new ExtensionComparer());
                    break;
                case Datas.Kind.Name:
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
