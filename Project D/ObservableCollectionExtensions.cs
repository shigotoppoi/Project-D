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
        public static void Sort<T,TKey>(this ObservableCollection<T> collection,Func<T,TKey> keySelector)
        {
            var r = collection.OrderBy(keySelector).ToList();
            collection.Clear();
            foreach(var t in r)
            {
                collection.Add(t);
            }
        }
    }
}
