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
    public class MainRuleViewModel : NotificationBase
    {
        public MainRuleViewModel()
        {
            _mainRule = new MainRuleModel();

            _mainRule.GetRules().ForEach(o =>
            {
                RuleViewModel rule = new RuleViewModel(o);
                Rules.Add(rule);
            });
        }

        private MainRuleModel _mainRule;


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

        public void AddRule(RuleViewModel rule)
        {
            _mainRule.AddRule(rule);
            Rules.Add(rule);
            SelectedIndex = Rules.IndexOf(rule);
        }

        public void RemoveRule()
        {
            if (SelectedRule != null)
            {
                var i = Rules.IndexOf(SelectedRule);
                _mainRule.RemoveRule(SelectedRule);
                Rules.Remove(SelectedRule);
                SelectedIndex = i.Equals(0) ? ++i : --i;
            }
        }

        public void ConfirmEdit(string Text)
        {
            SelectedRule.IsEditable = true;
            RaisePropertyChanged(nameof(SelectedRule));
        }
    }
}
