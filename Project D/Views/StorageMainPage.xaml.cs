using Project_D.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.Storage.Pickers;

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

        private object _RightTappedData;
        internal StorageMainViewModel StorageMain { get; set; }

        private async void FileMainGrid_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var items = await e.DataView.GetStorageItemsAsync();
                foreach (var item in items)
                {
                    if (item is StorageFile storageFile)
                    {
                        var bitmapImage = new BitmapImage();
                        bitmapImage.SetSource(await storageFile.GetThumbnailAsync(Windows.Storage.FileProperties.ThumbnailMode.SingleItem));
                        
                        StorageMain.AddStorage(storageFile.DisplayName, storageFile.Path, bitmapImage, storageFile.FileType);
                    }
                    else if (item is StorageFolder storageFolder)
                    {
                        var bitmapImage = new BitmapImage();
                        bitmapImage.SetSource(await storageFolder.GetThumbnailAsync(Windows.Storage.FileProperties.ThumbnailMode.SingleItem));
                        StorageMain.AddStorage(storageFolder.DisplayName, storageFolder.Path, bitmapImage, null);
                    }
                }
            }
        }

        private void StorageGrid_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Link;
        }

        private void SortedKind_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = e.AddedItems.FirstOrDefault();
            StorageMain.SortStorage(item);
        }

        private void SortedKind_DropDownClosed(object sender, object e)
        {
            var cb = sender as ComboBox;
            StorageMain.SortStorage(cb.SelectedItem);
        }

        private void StoragesViewMenu_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuFlyoutItem;
            switch(item.Name)
            {
                case nameof(DeleteMenu):
                    StorageMain.RemoveStorages(StoragesGridView.SelectedItems);
                    break;
                case nameof(RenameMenu):
                    
                    break;
                default:
                    break;
            }
        }

        private void StoragesGridView_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            _RightTappedData= (e.OriginalSource as FrameworkElement)?.DataContext;
        }
    }
}
