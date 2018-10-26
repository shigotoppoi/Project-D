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
        public OutcomeCategoryViewModel(OutcomeCategory category, string displayName, int count)
        {
            Category = category;
            DisplayName = displayName;
            Count = count;
        }

        public OutcomeCategory Category { get; }
        public int Count { get; }
        public string DisplayName { get; }
    }
}
