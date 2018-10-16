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
    public class RuleMainViewModel : NotificationBase
    {
        public RuleMainViewModel()
        {
            _RuleMain = new RuleMainModel();

            _RuleMain.GetRules().ForEach(o =>
            {
                RuleViewModel rule = new RuleViewModel(o);
                Rules.Add(rule);
            });

            RemoveRuleCommand = new RelayParameterCommand(RemoveRule);
            AddRuleCommand = new RelayParameterCommand(AddRule);
        }

        private RuleMainModel _RuleMain;

        public RelayParameterCommand RemoveRuleCommand { get; }
        public RelayParameterCommand AddRuleCommand { get; }
        public ObservableCollection<RuleViewModel> Rules { get; } = new ObservableCollection<RuleViewModel>();

        public RuleViewModel SelectedRule
        {
            get { return (_selectedIndex >= 0) ? Rules[_selectedIndex] : null; }
        }

        private int _selectedIndex = -1;
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

        public void RemoveRule(object item)
        {
            if (item is RuleViewModel rule)
            {
                SelectedIndex = Rules.IndexOf(rule);
                _RuleMain.RemoveRule(rule);
                Rules.Remove(rule);
            }
        }

        public void EditRule(string name, string destination, bool creatIfNone, bool replaceIfExist, string extensions, string format)
        {
            SelectedRule.Name = name;
            SelectedRule.Destination = destination;
            SelectedRule.CreateIfNone = creatIfNone;
            SelectedRule.ReplaceIfExist = replaceIfExist;
            SelectedRule.Extensions = extensions;
            SelectedRule.Format = format;
        }

        public void AddRule(object item)
        {
            if(item is RuleViewModel rule)
            {
                if(!Rules.Contains(rule))
                {
                    _RuleMain.AddRule(rule);
                    Rules.Add(rule);
                    SelectedIndex = Rules.IndexOf(rule);
                }
            }
        }
    }
}
