using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_D.ViewModels
{
    internal abstract class StorageComparerBase : IComparer<StorageViewModel>
    {
        protected StorageComparerBase(Direction direction)
        {
            Direction = direction;
        }

        public Direction Direction { get; }

        protected CaseInsensitiveComparer CaseComparer = new CaseInsensitiveComparer();

        public abstract int Compare(StorageViewModel x, StorageViewModel y);

        protected int Flow(int result)
        {
            if (Direction.Equals(Direction.Ascendant))
            {
                return result;
            }
            else
            {
                return result * -1;
            }
        }
    }
}
