﻿using System;
using System.Collections.Generic;

namespace AlgorithmTest
{
    public static class MergeSort
    {
        public static ICollection<T> Sort<T>(ICollection<T> source, Func<T, T, int> comparator)
        {
            return source;
        }

        public static ICollection<T> Sort<T>(ICollection<T> source) where T : IComparable<T>
        {
            return Sort(source, (x, y) => x.CompareTo(y));;
        }
    }
}