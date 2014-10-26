using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace AlgorithmTest
{
    public static class QuickSelection
    {
        public static T Select<T>(IList<T> source, int k, Func<T, T, int> comparator)
        {
            source.Shuffle();
            return SelectImpl(source, k, 0, source.Count - 1, comparator);
        }

        private static T SelectImpl<T>(IList<T> source, int k, int lo, int hi, Func<T, T, int> comparator)
        {
            if (lo == hi)
                return source[lo];

            var partIndex = Partition(source, lo, hi, comparator);

            if (k < partIndex)
            {
                return SelectImpl(source, k, lo, partIndex - 1, comparator);
            }
            
            if (k > partIndex)
            {
                return SelectImpl(source, k, partIndex + 1, hi, comparator);
            }

            return source[k];
        }

        private static int Partition<T>(IList<T> source, int lo, int hi, Func<T, T, int> comparator)
        {
            var i = lo;
            var j = hi + 1;

            while (true)
            {
                while (comparator(source[++i], source[lo]) < 0)
                    if (i == hi) break;

                while (comparator(source[--j], source[lo]) > 0)
                    if (j == lo) break;

                if (i >= j) break;

                source.Swap(i, j);
            }

            source.Swap(lo, j);

            return j;
        }

        public static T Select<T>(IList<T> source, int k) where T : IComparable<T>
        {
            return Select(source, k, (x, y) => x.CompareTo(y));
        }
    }
}
