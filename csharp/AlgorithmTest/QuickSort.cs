using System;
using System.Collections.Generic;

namespace AlgorithmTest
{
    public class QuickSort
    {

        public static IList<T> Sort<T>(IList<T> source, Func<T, T, int> comparator)
        {
            Shuffle(source);

            SortImpl(source, 0, source.Count - 1, comparator);
            

            return source;
        }

        private static void Shuffle<T>(IList<T> source)
        {
            var rand = new Random();
            for (var i = 0; i < source.Count; ++i)
            {
                source.Swap(i, rand.Next(i, source.Count));
            }
        }

        private static void SortImpl<T>(IList<T> source, int lo, int hi, Func<T, T, int> comparator)
        {
            if (lo >= hi)
                return;

            int j = Partition(source, lo, hi, comparator);

            SortImpl(source, lo, j - 1, comparator);
            SortImpl(source, j + 1, hi, comparator);
        }

        private static int Partition<T>(IList<T> source, int lo, int hi, Func<T, T, int> comparator)
        {
            var i = lo;
            var j = hi + 1;

            while (true)
            {
                while (comparator(source[++i], source[lo]) < 0)
                {
                    if (i == hi)
                        break;
                }

                while (comparator(source[--j], source[lo]) > 0)
                {
                    if (j == lo)
                        break;
                }

                if (i >= j)
                {
                    break;
                }

                source.Swap(i, j);
            }

            source.Swap(lo, j);
            return j;
        }

        public static IList<T> Sort<T>(IList<T> source) where T : IComparable<T>
        {
            return Sort(source, (x, y) => x.CompareTo(y));
        }
    }
}
