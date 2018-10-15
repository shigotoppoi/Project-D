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
    public sealed partial class RuleDetailPage : Page
    {
        public RuleDetailPage()
        {
            this.InitializeComponent();
        }

        private RuleViewModel Rule { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Rule = e.Parameter as RuleViewModel;

            base.OnNavigatedTo(e);
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).WorkContent.Rule = Rule;
            var frame = (Window.Current.Content as Frame);
            frame.Navigate(typeof(StorageMainPage));
        }
    }
}
