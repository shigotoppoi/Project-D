using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_D.Datas;

namespace Project_D.Models
{
    class SortModel
    {
        public IEnumerable<Sort> GetSorts()
        {
            return new List<Sort>
            {
                new Sort{Text= "Name",Kind= Kind.Name,Direction= Direction.Ascendant },
                new Sort{Text="Extension",Kind=Kind.Extension },
                new Sort{Text= "Path",Kind=Kind.Path },
            }.OrderBy(o => (int)o.Kind);
        }
    }
}
