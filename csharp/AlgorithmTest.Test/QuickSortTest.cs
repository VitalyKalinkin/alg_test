using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AlgorithmTest.Test
{
    [TestFixture]
    public class QuickSortTest : SortingTest
    {
        private static readonly int[][] ToSort = ToSortBase;
        private static readonly int[][] ToReallyHardSortWork = ToReallyHardSortWorkBase;

        [TestCaseSource("ToSort")]
        public void SimpleCases(IList<int> paramCollection)
        {
            var result = QuickSort.Sort(paramCollection.Clone().ToList());
            Assert.That(result, MoreThan.Sorted<int>());
        }

        [TestCaseSource("ToReallyHardSortWork")]
        public void HeavyCases(IList<int> paramCollection)
        {
            var result = QuickSort.Sort(paramCollection.Clone().ToList());
            Assert.That(result, MoreThan.Sorted<int>());
        }
    }
}