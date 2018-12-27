using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_D.Datas;

namespace Project_D.ViewModels
{
    class OutcomeCategoryViewModel
    {
        public OutcomeCategoryViewModel(OutcomeCategory category, IEnumerable<OutcomeViewModel> outcomes, string displayName)
        {
            Category = category;
            DisplayName = displayName;
            Outcomes = outcomes;
        }

        public OutcomeCategory Category { get; }
        public int Count { get => Outcomes.Count(); }
        public string DisplayName { get; }
        public IEnumerable<OutcomeViewModel> Outcomes { get; }
    }
}
