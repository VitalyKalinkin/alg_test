using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmTest.Test
{
    public static class Extentions
    {
        public static IEnumerable<T> Clone<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Select(x => x);
        } 
    }
}
