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

        public static void Shuffle<T>(this IList<T> source)
        {
            var rand = new Random();
            for (var i = 0; i < source.Count; ++i)
            {
                source.Swap(i, rand.Next(i, source.Count));
            }
        }
    }
}
