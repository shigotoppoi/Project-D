using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_D.Models;

namespace Project_D.ViewModels
{
    class FileMainViewModel : NotificationBase
    {
        public FileMainViewModel()
        {
            _fileModel = new FileModel();

        }

        private FileModel _fileModel;

        public ObservableCollection<FileViewModel> Files = new ObservableCollection<FileViewModel>();


    }
}
