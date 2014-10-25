using System;
using System.Collections.Generic;

namespace AlgorithmTest
{
    public static class InsertionSort
    {
        public static IList<T> Sort<T>(IList<T> source, Func<T, T, int> comparator)
        {
            for (var i = 0; i < source.Count; ++i)
            {
                for (var j = i; j > 0; --j)
                {
                    if (comparator(source[j], source[j - 1]) < 0)
                    {
                        source.Swap(j, j - 1);
                    }
                }
            }

            return source;
        }

        public static IList<T> Sort<T>(IList<T> source) where T : IComparable<T>
        {
            return Sort(source, (x, y) => x.CompareTo(y));
        }
    }
}
