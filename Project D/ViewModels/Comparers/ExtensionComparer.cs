using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_D.ViewModels
{
    class ExtensionComparer : StorageComparerBase
    {        
        public ExtensionComparer(Direction direction=Direction.Ascendant):base(direction)
        {
        }

        public override int Compare(StorageViewModel x, StorageViewModel y)
        {
            return Flow(CaseComparer.Compare(x.Extension, y.Extension));
        }
    }
}
