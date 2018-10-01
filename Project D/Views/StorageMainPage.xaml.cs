using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Project_D.ViewModels;
using Windows.ApplicationModel.DataTransfer;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Project_D.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StorageMainPage : Page
    {
        public StorageMainPage()
        {
            this.InitializeComponent();

            StorageMain = new StorageMainViewModel();
        }

        StorageMainViewModel StorageMain { get; set; }

        private async void FileMainGrid_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var items = await e.DataView.GetStorageItemsAsync();
                foreach(var item in items)
                {
                    StorageViewModel storage = new StorageViewModel();
                    if (item is StorageFile storageFile)
                    {
                        var bitmapImage = new BitmapImage();
                        bitmapImage.SetSource(await storageFile.GetThumbnailAsync(Windows.Storage.FileProperties.ThumbnailMode.SingleItem));
                        storage.DisplayName = storageFile.DisplayName;
                        storage.Path = storageFile.Path;
                        storage.Thumbnail = bitmapImage;
                    }
                    else if(item is StorageFolder storageFolder)
                    {
                        var bitmapImage = new BitmapImage();
                        bitmapImage.SetSource(await storageFolder.GetThumbnailAsync(Windows.Storage.FileProperties.ThumbnailMode.SingleItem));
                        storage.DisplayName = storageFolder.DisplayName;
                        storage.Path = storageFolder.Path;
                        storage.Thumbnail = bitmapImage;
                    }

                    StorageMain.AddStorage(storage);
                }
            }
        }

        private void FileMainGrid_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Link;
        }
    }
}
