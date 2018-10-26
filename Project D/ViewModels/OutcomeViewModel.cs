using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_D.Datas;

namespace Project_D.ViewModels
{
    class OutcomeViewModel
    {
        public OutcomeViewModel(Outcome outcome)
        {
            _outcome = outcome;
        }

        Outcome _outcome;

        public OutcomeCategory Category => _outcome.Category;
        public string DisplayName => _outcome.Storage.Name;
    }
}
