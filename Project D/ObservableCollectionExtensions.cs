using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_D
{
    internal static class ObservableCollectionExtensions
    {
        public static void Sort<T>(this ObservableCollection<T> collection, IComparer<T> comparer)
        {
            SortedSet<T> sort = new SortedSet<T>(collection, comparer);
            collection.Clear();
            foreach (var t in sort)
            {
                collection.Add(t);
            }
        }
    }
}
