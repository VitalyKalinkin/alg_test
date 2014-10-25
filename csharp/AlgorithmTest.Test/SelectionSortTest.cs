using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace AlgorithmTest.Test
{
    [TestFixture]
    public class SelectionSortTest : SortingTest
    {
        private static readonly int[][] ToSort = ToSortBase;

        [TestCaseSource("ToSort")]
        public void SimpleCases(ICollection<int> paramCollection)
        {
            var result = SelectionSort.Sort(paramCollection);
            Assert.That(result, MoreThan.Sorted<int>());
        }
    }
}