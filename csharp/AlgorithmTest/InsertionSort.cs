using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmTest
{
    public static class InsertionSort
    {
        public static ICollection<T> Sort<T>(ICollection<T> source, Func<T, T, int> comparator)
        {
            return source;
        }

        public static ICollection<T> Sort<T>(ICollection<T> source) where T : IComparable<T>
        {
            return Sort(source, (x, y) => x.CompareTo(y)); ;
        }
    }
}
