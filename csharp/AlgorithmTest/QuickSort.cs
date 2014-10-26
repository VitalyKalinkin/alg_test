using System;
using System.Collections.Generic;

namespace AlgorithmTest
{
    public class QuickSort
    {

        public static IList<T> Sort<T>(IList<T> source, Func<T, T, int> comparator)
        {
            source.Shuffle();

            SortImpl(source, 0, source.Count - 1, comparator);
            
            return source;
        }

        public static IList<T> Sort3Way<T>(IList<T> source, Func<T, T, int> comparator)
        {
            source.Shuffle();

            Sort3WayImpl(source, 0, source.Count - 1, comparator);

            return source;
        }

        private static void Sort3WayImpl<T>(IList<T> source, int lo, int hi, Func<T, T, int> comparator)
        {
            if (hi <= lo)
                return;

            var lt = lo;
            var gt = hi;
            var i = lo;
            var v = source[lo];

            while (i <= gt)
            {
                var cmp = comparator(source[i], v);
                if (cmp < 0) source.Swap(lt++, i++);
                else if (cmp > 0) source.Swap(i, gt--);
                else i++;
            }

            SortImpl(source, lo, lt - 1, comparator);
            SortImpl(source, gt + 1, hi, comparator);
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

        public static IList<T> Sort3Way<T>(IList<T> source) where T : IComparable<T>
        {
            return Sort3Way(source, (x, y) => x.CompareTo(y));
        }
    }
}
