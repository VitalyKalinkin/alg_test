using System;
using System.Collections.Generic;

namespace AlgorithmTest
{
    public static class ShellSort
    {
        public static IList<T> Sort<T>(IList<T> source, Func<T, T, int> comparator)
        {
            var h = 1;

            while (h <= source.Count)
            {
                h = h*3 + 1;
            }

            while (h > 0)
            {
                // We only need to sort a range from h till the end of the list. 
                // Part from 0 to h contains only one item for each shift.
                for (var i = h; i < source.Count; i++)
                {
                    for (var j = i; j >= h && comparator(source[j], source[j - h]) < 0; j -= h)
                    {
                        source.Swap(j, j - h);
                    }
                }

                h /= 3;
            }

            return source;
        }

        public static IList<T> Sort<T>(IList<T> source) where T : IComparable<T>
        {
            return Sort(source, (x, y) => x.CompareTo(y));
        }
    }
}
