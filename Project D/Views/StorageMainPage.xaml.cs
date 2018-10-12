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
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

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

        private GridViewItem _RightTappedGridViewItem;
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
                        //await storageFile.RenameAsync("sssss");
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
            switch (item.Name)
            {
                case nameof(DeleteMenu):
                    StorageMain.RemoveStorages(StoragesGridView.SelectedItems);
                    break;
                case nameof(RenameMenu):
                    //if (_RightTappedGridViewItem != null)
                    //{
                    //    var show = _RightTappedGridViewItem.FindDescendantByName("ShowName");
                    //    var edit = _RightTappedGridViewItem.FindDescendantByName("EditName");
                    //    show.Visibility = Visibility.Collapsed;
                    //    edit.Visibility = Visibility.Visible;

                    //}
                    break;
                default:
                    break;
            }

            TextBox d = new TextBox();
            //d.focu
        }

        private void StoragesGridView_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            var item = (e.OriginalSource as FrameworkElement)?.DataContext;
            _RightTappedGridViewItem = StoragesGridView.ContainerFromItem(item) as GridViewItem;
        }

        private void StoragesGridView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void EditName_LostFocus(object sender, RoutedEventArgs e)
        {
            //if (_RightTappedGridViewItem != null)
            //{
            //    var show = _RightTappedGridViewItem.FindDescendantByName("ShowName");
            //    var edit = _RightTappedGridViewItem.FindDescendantByName("EditName");
            //    show.Visibility = Visibility.Visible;
            //    edit.Visibility = Visibility.Collapsed;

            //    StorageMain.RenameStorage(edit.DataContext);
            //}

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack) Frame.GoBack();
        }
    }
}
