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
            SettingRuleModel settingRuleModel = new SettingRuleModel();
            foreach (var rule in settingRuleModel.GetRules())
            {
                _rules.Add(new RuleViewModel(rule));
            }
        }

        private ObservableCollection<RuleViewModel> _rules = new ObservableCollection<RuleViewModel>();
        public ObservableCollection<RuleViewModel> Rules { get => _rules; }

        private int _selectedIndex = -1;
        public int SelectedIndex
        {
            get => _selectedIndex;
            //set => SetProperty(ref _selectedIndex, value);
            set
            {
                if (SetProperty(ref _selectedIndex, value))
                {
                    RaisePropertyChanged(nameof(SelectedRule));
                }
            }
        }

        private RuleViewModel _selectedRule = null;
        public RuleViewModel SelectedRule
        {
            //get => _selectedIndex > -1 ? _rules[_selectedIndex] : null;
            get => _selectedRule;
            set => SetProperty(_selectedRule, value, () => _selectedRule = value);
        }
    }
}
