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
    public sealed partial class RuleMasterPage : Page
    {
        public RuleMasterPage()
        {
            this.InitializeComponent();
            MainRule = new RuleMasterViewModel();
        }

        public RuleMasterViewModel MainRule { get; set; }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RuleViewModel rule = e.Parameter as RuleViewModel;

            if (rule != null)
            {
                MainRule.AddRule(rule);
            }

            base.OnNavigatedTo(e);
        }


        private void Rules_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RuleDetailFrame.Navigate(typeof(DisplayRuleDetailPage), MainRule.SelectedRule);
        }

        private void Rules_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void ConfirmEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddRuleButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EditRuleDetailPage));
        }

        private void EditRuleButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EditRuleDetailPage), MainRule.SelectedRule);
        }
    }
}
