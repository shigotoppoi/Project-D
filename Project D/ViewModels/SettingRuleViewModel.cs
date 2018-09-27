using Project_D.Datas;
using Project_D.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_D.ViewModels
{
    public class SettingRuleViewModel : NotificationBase
    {
        public SettingRuleViewModel()
        {
            _settingRule = new SettingRuleModel();

            _settingRule.GetRules().ForEach(o =>
            {
                RuleViewModel rule = new RuleViewModel(o);
                Rules.Add(rule);
            });
        }

        private SettingRuleModel _settingRule;


        public ObservableCollection<RuleViewModel> Rules { get; } = new ObservableCollection<RuleViewModel>();

        public RuleViewModel SelectedRule
        {
            get { return (_selectedIndex >= 0) ? Rules[_selectedIndex] : null; }
        }

        private int _selectedIndex = 0;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (SetProperty(ref _selectedIndex, value))
                {
                    RaisePropertyChanged(nameof(SelectedRule));
                }
            }
        }

        public void AddRule()
        {
            RuleViewModel rule = new RuleViewModel
            {
                IsEdit = true
            };
            _settingRule.AddRule(rule);
            Rules.Add(rule);
            SelectedIndex = Rules.IndexOf(rule);
        }

        public void RemoveRule()
        {
            _settingRule.RemoveRule(SelectedRule);
            Rules.Remove(SelectedRule);
        }

        public void ConfirmEdit(string Text)
        {
            SelectedRule.IsEdit = true;
            RaisePropertyChanged(nameof(SelectedRule));
        }
    }
}
