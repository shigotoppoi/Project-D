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
            if (listBox.SelectedIndex.Equals(-1)) return;
            
            var outcomeCategory = listBox.SelectedItem as OutcomeCategoryViewModel;
            OutcomeDetail.ItemsSource = _resultMain.Outcomes.ContainsKey(outcomeCategory.Category) ? _resultMain.Outcomes[outcomeCategory.Category] : null;
            CategoryName.Text = outcomeCategory.DisplayName;
            StoragesNumber.Text = outcomeCategory.Count.ToString();
            OutcomeContent.IsPaneOpen = true;
        }

        private void OutcomeContent_PaneClosed(SplitView sender, object args)
        {
            OutcomeCategorys.SelectedItem = null;
        }
    }
}
