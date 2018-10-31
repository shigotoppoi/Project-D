using Project_D.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Project_D.ViewModels
{
    internal class ResultMainViewModel
    {
        public ResultMainViewModel(object result)
        {
            OutcomeCategorys = new List<OutcomeCategoryViewModel>();
            Outcomes = new Dictionary<OutcomeCategory, IEnumerable<OutcomeViewModel>>();

            OutcomeCategorys.Add(new OutcomeCategoryViewModel(OutcomeCategory.FolderNotFound, "TEST1", 2));
            OutcomeCategorys.Add(new OutcomeCategoryViewModel(OutcomeCategory.MissingSource, "TEST2", 2));
            OutcomeCategorys.Add(new OutcomeCategoryViewModel(OutcomeCategory.NewFolder, "TEST3", 1));
            OutcomeCategorys.Add(new OutcomeCategoryViewModel(OutcomeCategory.Success, "TEST4", 1));

            var foldernotfounds = new List<OutcomeViewModel> {
                new OutcomeViewModel(new Outcome { Category = OutcomeCategory.FolderNotFound, Storage = new Storage { Name = "AAA" } }),
                new OutcomeViewModel(new Outcome { Category = OutcomeCategory.FolderNotFound, Storage = new Storage { Name = "AAA2" } }),
                new OutcomeViewModel(new Outcome { Category = OutcomeCategory.FolderNotFound, Storage = new Storage { Name = "AAA3" } }),
                new OutcomeViewModel(new Outcome { Category = OutcomeCategory.FolderNotFound, Storage = new Storage { Name = "AAA4" } }),
            };
            Outcomes.Add(OutcomeCategory.FolderNotFound, foldernotfounds);
            Outcomes.Add(OutcomeCategory.MissingSource, new List<OutcomeViewModel> { new OutcomeViewModel(new Outcome { Category = OutcomeCategory.MissingSource, Storage = new Storage { Name = "BBB" } }) });
            Outcomes.Add(OutcomeCategory.NewFolder, new List<OutcomeViewModel> { new OutcomeViewModel(new Outcome { Category = OutcomeCategory.NewFolder, Storage = new Storage { Name = "CCC" } }) });
            Outcomes.Add(OutcomeCategory.Success, new List<OutcomeViewModel> { new OutcomeViewModel(new Outcome { Category = OutcomeCategory.Success, Storage = new Storage { Name = "DDD" } }) });

            if (result != null)
            {
                var items = result as IEnumerable<OutcomeViewModel>;
                foreach (OutcomeCategory status in Enum.GetValues(typeof(OutcomeCategory)))
                {
                    var filteredItems = items.Where(o => o.Category.Equals(status));
                    var category = new OutcomeCategoryViewModel(status, status.ToString(), filteredItems.Count());
                    OutcomeCategorys.Add(category);
                    Outcomes.Add(status, filteredItems);
                }
            }
        }


        public List<OutcomeCategoryViewModel> OutcomeCategorys { get; }

        public Dictionary<OutcomeCategory, IEnumerable<OutcomeViewModel>> Outcomes { get; }

        public IEnumerable<OutcomeViewModel> GetOutcomes (object outcomeCategory)
        {
            if(outcomeCategory is OutcomeCategoryViewModel outcomeCategoryViewModel && Outcomes.ContainsKey(outcomeCategoryViewModel.Category))
            {
                return Outcomes[outcomeCategoryViewModel.Category];
            }
            else
            {
                return null;
            }
        }

        public string GetCategoryName(object outcomeCategory)
        {
            if (outcomeCategory is OutcomeCategoryViewModel outcomeCategoryViewModel)
            {
                return outcomeCategoryViewModel.DisplayName;
            }
            else
            {
                return null;
            }
        }
    }
}
