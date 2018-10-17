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
        public StorageViewModel(Storage storage = null) : base(storage) { }

        public string Name
        {
            get => This.Name;
            set => SetProperty(This.Name, value, () => This.Name = value);
        }

        public string Path
        {
            get => This.Path;
            set => SetProperty(This.Path, value, () => This.Path = value);
        }

        public BitmapImage Thumbnail
        {
            get =>This.Thumbnail;
            set => SetProperty(This.Thumbnail, value, () => This.Thumbnail = value);
        }

        public string Extension
        {
            get =>This.Extension;
            set => SetProperty(This.Extension, value, () => This.Extension = value);
        }


        public StorageItemTypes StorageType
        {
            get => This.StorageType;
            set => SetProperty(This.StorageType, value, () => This.StorageType = value);
        }
    }
}
