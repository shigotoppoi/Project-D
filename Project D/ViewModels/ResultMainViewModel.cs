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

            var foldernotfounds = new List<OutcomeViewModel> {
                new OutcomeViewModel { Category = OutcomeCategory.FolderNotFound, Storage = new Storage { Name = "AAA" } },
                new OutcomeViewModel { Category = OutcomeCategory.FolderNotFound, Storage = new Storage { Name = "AAA2" } },
                new OutcomeViewModel { Category = OutcomeCategory.FolderNotFound, Storage = new Storage { Name = "AAA3" } },
                new OutcomeViewModel { Category = OutcomeCategory.FolderNotFound, Storage = new Storage { Name = "AAA4" } },
                new OutcomeViewModel { Category = OutcomeCategory.FolderNotFound, Storage = new Storage { Name = "AAA5" } } ,
            };
            var miss = new List<OutcomeViewModel> { new OutcomeViewModel { Category = OutcomeCategory.NewFolder, Storage = new Storage { Name = "CCC" } } };
            var newf = new List<OutcomeViewModel> { new OutcomeViewModel { Category = OutcomeCategory.NewFolder, Storage = new Storage { Name = "CCC" } } };
            var succ = new List<OutcomeViewModel> { new OutcomeViewModel { Category = OutcomeCategory.Success, Storage = new Storage { Name = "DDD" } } };

            OutcomeCategorys.Add(new OutcomeCategoryViewModel(OutcomeCategory.FolderNotFound, foldernotfounds, "TEST1"));
            OutcomeCategorys.Add(new OutcomeCategoryViewModel(OutcomeCategory.MissingSource, miss, "TEST2"));
            OutcomeCategorys.Add(new OutcomeCategoryViewModel(OutcomeCategory.NewFolder, newf, "TEST3"));
            OutcomeCategorys.Add(new OutcomeCategoryViewModel(OutcomeCategory.Success, succ, "TEST4"));

            if (result != null)
            {
                var items = result as IEnumerable<OutcomeViewModel>;
                foreach (OutcomeCategory status in Enum.GetValues(typeof(OutcomeCategory)))
                {
                    var filteredItems = items.Where(o => o.Category.Equals(status));
                    var category = new OutcomeCategoryViewModel(status, filteredItems, status.ToString());
                    OutcomeCategorys.Add(category);
                }
            }
        }


        public List<OutcomeCategoryViewModel> OutcomeCategorys { get; }


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
