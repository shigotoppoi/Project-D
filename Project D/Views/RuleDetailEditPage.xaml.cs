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
    public sealed partial class RuleDetailEditPage : Page
    {
        public RuleDetailEditPage()
        {
            this.InitializeComponent();
        }

        public RuleViewModel Rule { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Rule = e.Parameter as RuleViewModel; 
            if(Rule is null)
            {
                Rule = new RuleViewModel();
            }

            base.OnNavigatedTo(e);
        }

        private void CancelEdit_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RuleMainPage));
        }

        private void ConfirmEdit_Click(object sender, RoutedEventArgs e)
        {
            RuleNameTextBox.GetBindingExpression(TextBlock.TextProperty).UpdateSource();
            //if (RuleMain.SelectedRule == null)
            //{
            //    RuleMain.AddRule(RuleNameTextBox.Text,
            //        DestinationTextBox.Text,
            //        CreateIfNewCheckBox.IsChecked ?? false,
            //        ReplaceIfExistCheckBox.IsChecked ?? false,
            //        ExtensionsTextBox.Text,
            //        FormatTextBox.Text);
            //}
            //else
            //{
            //    RuleMain.EditRule(RuleNameTextBox.Text,
            //        DestinationTextBox.Text,
            //        CreateIfNewCheckBox.IsChecked ?? false,
            //        ReplaceIfExistCheckBox.IsChecked ?? false,
            //        ExtensionsTextBox.Text,
            //        FormatTextBox.Text);
            //}

            Frame.Navigate(typeof(RuleMainPage), Rule);
        }
    }
}
