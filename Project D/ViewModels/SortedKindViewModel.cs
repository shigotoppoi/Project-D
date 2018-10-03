using Project_D.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_D.ViewModels
{
    internal class SortedKindViewModel
    {
        public SortedKindViewModel(SortedKind sortedKind)
        {
            _sortedKind = sortedKind;
        }

        SortedKind _sortedKind;

        public Kind Kind => _sortedKind.Kind;
        public string Content => _sortedKind.Content;

        public override string ToString()
        {
            return Content;
        }
    }
}
