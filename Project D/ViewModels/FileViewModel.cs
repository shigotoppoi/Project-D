using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_D.Datas;

namespace Project_D.ViewModels
{
    class FileViewModel:NotificationBase<File>
    {
        public FileViewModel(File file = null) : base(file)
        {

        }

        public string Filename
        {
            get => This.Filename;
            set => SetProperty(This.Filename, value, () => This.Filename = value);
        }
    }
}
