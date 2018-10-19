using Project_D.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Project_D.ViewModels
{
    internal class ResultMainViewModel
    {
        public ResultMainViewModel(object result)
        {
            _summary = result as Summery;;
        }

        private Summery _summary { get; }

        public List<Storage> SuccessFiles => _summary.Success.Where(o => o.StorageType.Equals(StorageItemTypes.File)).ToList();
        public IEnumerable<Storage> SuccessFolders => _summary.Success.Where(o => o.StorageType.Equals(StorageItemTypes.Folder));
        public IEnumerable<Storage> FailureFiles => _summary.Failure.Where(o => o.StorageType.Equals(StorageItemTypes.File));
        public IEnumerable<Storage> FailureFolders => _summary.Failure.Where(o => o.StorageType.Equals(StorageItemTypes.Folder));
        public IEnumerable<Storage> NotFoundFolders => _summary.NotFoundFolders;
        public IEnumerable<Storage> NewFolders => _summary.NewFolders;
    }
}
