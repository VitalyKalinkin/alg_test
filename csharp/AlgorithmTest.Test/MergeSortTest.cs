using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AlgorithmTest.Test
{
    [TestFixture]
    public class MergeSortTest : SortingTest
    {
        private static readonly int[][] ToSort = ToSortBase;
        private static readonly int[][] ToReallyHardSortWork = ToReallyHardSortWorkBase;

        [TestCaseSource("ToSort")]
        public void SimpleCases(IList<int> paramCollection)
        {
            var result = MergeSort.Sort(paramCollection.Clone().ToList());
            Assert.That(result, MoreThan.Sorted<int>());
        }

        [TestCaseSource("ToReallyHardSortWork")]
        public void HeavyCases(IList<int> paramCollection)
        {
            var result = MergeSort.Sort(paramCollection.Clone().ToList());
            Assert.That(result, MoreThan.Sorted<int>());
        }

        [TestCaseSource("ToSort")]
        public void SimpleNonRecursiveCases(IList<int> paramCollection)
        {
            var result = MergeSort.SortNonRecursive(paramCollection.Clone().ToList());
            Assert.That(result, MoreThan.Sorted<int>());
        }

        [TestCaseSource("ToReallyHardSortWork")]
        public void HeavyNonRecursiveCases(IList<int> paramCollection)
        {
            var result = MergeSort.SortNonRecursive(paramCollection.Clone().ToList());
            Assert.That(result, MoreThan.Sorted<int>());
        }
    }
}