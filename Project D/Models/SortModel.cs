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
                new Sort("Name",Kind.Name,Direction.Ascendant),
                new Sort("Extension",Kind.Extension),
                new Sort("Path",Kind.Path),
            }.OrderBy(o => (int)o.Kind);
        }
    }
}
