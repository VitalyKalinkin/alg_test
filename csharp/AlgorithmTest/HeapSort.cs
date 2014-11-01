using System;
using System.Collections.Generic;

namespace AlgorithmTest
{
    public static class HeapSort<T> where T: IComparable<T>
    {
        public static IList<T> Sort(IList<T> source)
        {
            var heap = ConstructHeap(source);
            return SortFromHeap(heap);
        }

        private static IList<T> ConstructHeap(IList<T> source)
        {
            for (var i = source.Count/2; i >= 0; --i)
            {
                Sink(source, i, source.Count);
            }

            return source;
        }

        private static IList<T> SortFromHeap(IList<T> source)
        {
            for (var i = source.Count - 1; i >= 0; --i)
            {
                source.Swap(i, 0);
                Sink(source, 0, i);
            }

            return source;
        }

        private static void Sink(IList<T> source, int k, int n)
        {
            while (2 * k + 1 < n)
            {
                var j = 2 * k + 1;
                if (j + 1 < n && source[j].CompareTo(source[j + 1]) < 0)
                    j++;

                if (source[k].CompareTo(source[j]) >= 0)
                {
                    break;
                }

                source.Swap(k, j);
                k = j;
            }
        }
    }
}
