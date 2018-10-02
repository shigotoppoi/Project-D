using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_D.Models;

namespace Project_D.ViewModels
{
    class StorageMainViewModel : NotificationBase
    {
        public StorageMainViewModel()
        {
            _storageMainModel = new StorageMainModel();

        }

        private StorageMainModel _storageMainModel;

        public ObservableCollection<StorageViewModel> Storages = new ObservableCollection<StorageViewModel>();

        public void AddStorage(StorageViewModel storage)
        {
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

        
    }
}
