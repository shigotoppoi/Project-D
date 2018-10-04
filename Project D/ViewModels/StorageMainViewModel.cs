
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
                DisplayName = "HHHHHHHHH",
                Path = "FFFFFFFFFFFFFF"
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

        public void AddStorage(string name, string path, BitmapImage image, string extension)
        {
            StorageViewModel storage = new StorageViewModel
            {
                DisplayName = name,
                Path = path,
                Thumbnail = image,
                Extension = extension,
            };
            _storageMainModel.AddStorage(storage);
            _Storages.Add(storage);
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
                var folder = Path.GetDirectoryName(storage.Path);
                var filename = Path.GetFileName(storage.Path);
                var storageFolder = await StorageFolder.GetFolderFromPathAsync(folder);
                var storageFile = await storageFolder.GetFileAsync(filename);
                //storageFile.RenameAsync()
            }
        }
    }
}
