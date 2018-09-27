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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Project_D.UserControls
{
    public sealed partial class SettingRuleUserControl : UserControl
    {
        public SettingRuleUserControl()
        {
            this.InitializeComponent();
        }

        public RuleViewModel Rule { get; set; }
        public string RuleName => Rule.Name;
        public string Destination => Rule.Destination;
        public string Format => Rule.Format;
        public bool CreateIfNew => Rule.CreateIfNew;
        public string Extensions => Rule.Extensions;

        private bool _IsEditable;
        public bool IsEditable
        {
            get => _IsEditable;
            set
            {
                _IsEditable = value;
                if (_IsEditable)
                {
                    RuleNameTb.IsEnabled = true;
                    DestinationTb.IsEnabled = true;
                    FormatTb.IsEnabled = true;
                    CreateIfNewCb.IsEnabled = true;
                    ExtensionsTb.IsEnabled = true;
                }
                else
                {
                    RuleNameTb.IsEnabled = false;
                    DestinationTb.IsEnabled = false;
                    FormatTb.IsEnabled = false;
                    CreateIfNewCb.IsEnabled = false;
                    ExtensionsTb.IsEnabled = false;
                }
            }
        }

        private void ConfirmEdit_Click(object sender, RoutedEventArgs e)
        {
            Rule.Name = RuleNameTb.Text;
            Rule.Destination = DestinationTb.Text;
            Rule.Format = FormatTb.Text;
            Rule.CreateIfNew = CreateIfNewCb.IsChecked ?? false;
            Rule.Extensions = ExtensionsTb.Text;
        }
    }
}
