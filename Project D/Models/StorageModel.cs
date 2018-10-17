using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_D.Datas;

namespace Project_D.Models
{
    class StorageModel
    {
        public StorageModel()
        {
            _storages = new List<Storage>();
        }

        private List<Storage> _storages;

        public void AddStorage(Storage storage)
        {
            if (!_storages.Contains(storage))
            {
                _storages.Add(storage);
            }
        }

        public void RemoveStorage(Storage storage)
        {
            if(!_storages.Contains(storage))
            {
                _storages.Remove(storage);
            }
        }

        public List<Storage> GetStorages()
        {
            return _storages;
        }
    }



}
