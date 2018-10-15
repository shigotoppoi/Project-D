using Project_D.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace Project_D.ViewModels
{
    public class StorageViewModel : NotificationBase<Storage>
    {
        public StorageViewModel(Storage file = null) : base(file)
        {

        }

        public string Name
        {
            get => This.Name;
            set => SetProperty(This.Name, value, () => This.Name = value);
        }

        public string Path
        {
            get => This.Path;
            set
            {
                if (Utility.CheckPath(value)) SetProperty(This.Path, value, () => This.Path = value);
                else SetProperty(This.Path, string.Empty, () => This.Path = string.Empty);
            }
        }

        public BitmapImage Thumbnail
        {
            get => This.Thumbnail;
            set => SetProperty(This.Thumbnail, value, () => This.Thumbnail = value);
        }

        public string Extension

        {
            get => This.Extension;
            set => SetProperty(This.Extension, value, () => This.Extension = value);
        }

        public bool IsFile => Extension is null ? false : true;
    }
}
