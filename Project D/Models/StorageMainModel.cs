using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_D.Datas;

namespace Project_D.Models
{
    class StorageMainModel
    {
        public StorageMainModel()
        {
            _files = new List<Storage>();
        }

        private List<Storage> _files;

        public void AddStorage(Storage file)
        {
            if (!_files.Contains(file))
            {
                _files.Add(file);
            }
        }

        public void RemoveStorage(Storage storage)
        {
            if(!_files.Contains(storage))
            {
                _files.Remove(storage);
            }
        }

        public List<Storage> GetStorages()
        {
            return _files;
        }
    }



}
