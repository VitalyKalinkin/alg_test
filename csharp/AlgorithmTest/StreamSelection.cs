using System;
using System.Collections.Generic;

namespace AlgorithmTest
{
    public class StreamSelection
    {
        public static T Select<T>(IEnumerable<T> source, int k, Func<T, T, int> comparator)
        {
            k = k + 1;
            var buffer = new T[k + 1];
            var size = 0;

            foreach (var item in source)
            {
                buffer[size] = item;

                for (var i = size; i > 0 && comparator(buffer[i], buffer[i - 1]) < 0; --i)
                {
                    buffer.Swap(i, i - 1);
                }

                if (++size > k)
                    size = k;
            }

            return buffer[k - 1];
        }

        public static T Select<T>(IEnumerable<T> source, int k) where T : IComparable<T>
        {
            return Select(source, k, (x, y) => x.CompareTo(y));
        }
    }
}
