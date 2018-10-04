using Project_D.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Project_D.ViewModels
{
    internal class StorageViewModel : NotificationBase<Storage>
    {
        public StorageViewModel(Storage file = null) : base(file)
        {

        }

        public string DisplayName
        {
            get => This.DisplayName;
            set => SetProperty(This.DisplayName, value, () => This.DisplayName = value);
        }

        public string Path
        {
            get => This.Path;
            set => SetProperty(This.Path, value, () => This.Path = value);
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
    }
}
