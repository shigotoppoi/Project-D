
using Project_D.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Project_D.ViewModels
{
    internal class StorageMainViewModel : NotificationBase
    {
        public StorageMainViewModel()
        {
            _storageMainModel = new StorageMainModel();
            _sortedKindModel = new SortedKindModel();

            foreach (var s in _sortedKindModel.GetSortedTypes())
            {
                SortedKinds.Add(new SortedKindViewModel(s));
            }
        }

        private StorageMainModel _storageMainModel;
        private SortedKindModel _sortedKindModel;

        public ObservableCollection<StorageViewModel> Storages = new ObservableCollection<StorageViewModel>();
        public ObservableCollection<SortedKindViewModel> SortedKinds = new ObservableCollection<SortedKindViewModel>();

        public void AddStorage(string name, string path, BitmapImage image)
        {
            StorageViewModel storage = new StorageViewModel
            {
                DisplayName = name,
                Path = path,
                Thumbnail = image,
            };
            _storageMainModel.AddStorage(storage);
            Storages.Add(storage);
        }

        public void RemoveStorages(IEnumerable<StorageViewModel> storages)
        {
            foreach (var storage in storages)
            {
                _storageMainModel.RemoveStorage(storage);
                Storages.Remove(storage);
            }
        }

        public void SortStorage(object arg)
        {
            var sortedKind = arg as SortedKindViewModel;
            if (sortedKind is null) return;

            switch (sortedKind.Kind)
            {
                case Datas.Kind.Path:
                    Storages.Sort(o => o.Path);
                    break;
                case Datas.Kind.Name:
                    Storages.Sort(o => o.DisplayName);
                    break;
            }

            // Storages = new ObservableCollection<StorageViewModel>();

        }

        public 
    }
}
