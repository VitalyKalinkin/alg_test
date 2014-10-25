using System;
using System.Collections.Generic;

namespace AlgorithmTest
{
    public static class MergeSort
    {
        public static IList<T> Sort<T>(IList<T> source, Func<T, T, int> comparator)
        {
            var aux = new T[source.Count];
            Sort(source, aux, 0, source.Count - 1, comparator);
            return source;
        }   

        private static void Sort<T>(IList<T> source, IList<T> aux, int lo, int hi, Func<T, T, int> comparator)
        {
            if (lo >= hi)
            {
                return;
            }

            var mid = lo + (hi - lo)/2;

            Sort(source, aux, lo, mid, comparator);
            Sort(source, aux, mid + 1, hi, comparator);
            Merge(source, aux, lo, mid, hi, comparator);
        }

        private static void Merge<T>(IList<T> source, IList<T> aux, int lo, int mid, int hi, Func<T, T, int> comparator)
        {
            for (var l = lo; l <= hi; l++)
            {
                aux[l] = source[l];
            }

            var i = lo;
            var j = mid + 1;

            for (var k = lo; k <= hi; k++)
            {
                if (i > mid)
                {
                    source[k] = aux[j++];
                }
                else if (j > hi)
                {
                    source[k] = aux[i++];
                    
                }
                else if (comparator(aux[i], aux[j]) < 0)
                {
                    source[k] = aux[i++];
                }
                else
                {
                    source[k] = aux[j++];
                }
            }
        }
        
        public static IList<T> Sort<T>(IList<T> source) where T : IComparable<T>
        {
            return Sort(source, (x, y) => x.CompareTo(y));;
        }
    }
}
