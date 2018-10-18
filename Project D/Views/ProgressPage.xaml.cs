using Project_D.ViewModels;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Project_D.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProgressPage : Page
    {
        public ProgressPage()
        {
            this.InitializeComponent();
            var work = (Application.Current as App).WorkContent;
            _progress = new StorageDispatcher(work.Storages, work.Rule);
            DataContext = _progress;
        }

        private IProgressViewModel _progress;

        private void CircularProgress_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if(_progress.Value.Equals(_progress.Maximum))
            {
                
            }
        }
    }
}
