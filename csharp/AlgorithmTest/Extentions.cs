using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmTest
{
    public static class Extentions
    {
        public static IEnumerable<T> Clone<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Select(x => x);
        }

        public static void Swap<T>(this IList<T> list, int i, int j)
        {
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}
