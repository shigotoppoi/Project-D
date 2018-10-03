using Project_D.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_D.Models
{
    internal class SortedKindModel
    {
        public IEnumerable<SortedKind> GetSortedTypes()
        {
            return new List<SortedKind>
            {
                new SortedKind(Kind.Name,"Name"),
                new SortedKind(Kind.Category,"Category"),
                new SortedKind(Kind.Path,"Path"),
            }.OrderBy(o => (int)o.Kind);
        }
    }
}
