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
        }

        private RuleMainModel _RuleMain;


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
            _RuleMain.AddRule(rule);
            Rules.Add(rule);
            SelectedIndex = Rules.IndexOf(rule);
        }

        public void RemoveRule()
        {
            if (SelectedRule != null)
            {
                var i = Rules.IndexOf(SelectedRule);
                _RuleMain.RemoveRule(SelectedRule);
                Rules.Remove(SelectedRule);
                SelectedIndex = i.Equals(0) ? ++i : --i;
            }
        }

        public void ConfirmEdit(string Text)
        {
            RaisePropertyChanged(nameof(SelectedRule));
        }
    }
}
