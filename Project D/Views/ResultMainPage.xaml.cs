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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Project_D.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ResultMainPage : Page
    {
        public ResultMainPage()
        {
            this.InitializeComponent();
        }

        ResultMainViewModel _resultMain;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _resultMain = new ResultMainViewModel(e.Parameter); 
            base.OnNavigatedTo(e);
        }

        private void OutcomeCategorys_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;

            OutcomePane.ItemsSource = _resultMain.GetOutcomes(listBox.SelectedItem );
            OutcomeContent.IsPaneOpen = true;
            listBox.SelectedIndex = -1; //???databinding會消失
        }
    }
}
