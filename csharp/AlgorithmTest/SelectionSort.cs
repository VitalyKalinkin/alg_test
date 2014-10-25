using System;
using System.Collections.Generic;

namespace AlgorithmTest
{
    public static class SelectionSort
    {
        public static IList<T> Sort<T>(IList<T> source, Func<T, T, int> comparator)
        {
            for (var i = 0; i < source.Count; ++i)
            {
                var minIndex = i;

                for (var j = i; j < source.Count; ++j)
                {
                    if (comparator(source[minIndex], source[j]) > 0)
                    {
                        minIndex = j;
                    }
                }

                T temp = source[i];
                source[i] = source[minIndex];
                source[minIndex] = temp;
            }

            return source;
        }

        public static IList<T> Sort<T>(IList<T> source) where T : IComparable<T>
        {
            return Sort(source, (x, y) => x.CompareTo(y));
        }
    }
}
