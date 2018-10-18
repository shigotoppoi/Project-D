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

        private async void TopGrid_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var items = await e.DataView.GetStorageItemsAsync();
                foreach (var item in items)
                {
                    if (item is StorageFile file)
                    {
                        var bitmapImage = new BitmapImage();
                        bitmapImage.SetSource(await file.GetThumbnailAsync(Windows.Storage.FileProperties.ThumbnailMode.SingleItem));
                        StorageMain.AddStorage(file.DisplayName, file.Path, bitmapImage, file.FileType, StorageItemTypes.File);
                    }
                    else if (item is StorageFolder folder)
                    {
                        var bitmapImage = new BitmapImage();
                        bitmapImage.SetSource(await folder.GetThumbnailAsync(Windows.Storage.FileProperties.ThumbnailMode.SingleItem));
                        StorageMain.AddStorage(folder.DisplayName, folder.Path, bitmapImage, null, StorageItemTypes.Folder);
                    }
                }
            }
        }

        private void TopGrid_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Link;
        }

        private void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = e.AddedItems.FirstOrDefault();
            StorageMain.SortStorage(item);
        }

        private void Sort_DropDownClosed(object sender, object e)
        {
            var cb = sender as ComboBox;
            StorageMain.SortStorage(cb.SelectedItem);
        }

        private void StorageViewMenu_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuFlyoutItem;
            switch (item.Name)
            {
                case nameof(DeleteMenu):
                    StorageMain.RemoveStorages(StorageView.SelectedItems);
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

        private void StorageView_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            var item = (e.OriginalSource as FrameworkElement)?.DataContext;
            _RightTappedGridViewItem = StorageView.ContainerFromItem(item) as GridViewItem;
        }

        private void StorageView_ItemClick(object sender, ItemClickEventArgs e)
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

        private void Execute_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).WorkContent.Storages = StorageMain.Storages;
            Frame.Navigate(typeof(ProgressPage));
        }

        private void SortListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            StorageMain.ChangeSort(e.ClickedItem);
            SortFlyout.Hide();
        }

        private void SortFlyout_Opening(object sender, object e)
        {
            e.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            e.ToString();
        }
    }
}
