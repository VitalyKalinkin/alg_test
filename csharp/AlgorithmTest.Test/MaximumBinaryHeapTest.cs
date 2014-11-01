using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AlgorithmTest.Test
{
    [TestFixture]
    public class MaximumBinaryHeapTest : SortingTest
    {
        private static readonly int[][] ToSort = ToSortBase;
        private static readonly int[][] ToReallyHardSortWork = ToReallyHardSortWorkBase;

        [TestCaseSource("ToSort")]
        public void SimpleCases(IList<int> paramCollection)
        {
            var expected = QuickSort.Sort(paramCollection.Clone().ToList(), (x, y) => y.CompareTo(x));
            var maximumHeap = new MaximumBinaryHeap<int>();

            foreach (var item in paramCollection)
            {
                maximumHeap.Add(item);
            }

            var actual = new List<int>(paramCollection.Count);
            actual.AddRange(Enumerable.Range(1, paramCollection.Count).Select(item => maximumHeap.GetMaxumum()));

            Assert.That(actual, MoreThan.Sorted<int>((x, y) => y.CompareTo(x)));
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource("ToReallyHardSortWork")]
        public void HeavyCases(IList<int> paramCollection)
        {
            var expected = QuickSort.Sort(paramCollection.Clone().ToList(), (x, y) => y.CompareTo(x));
            var maximumHeap = new MaximumBinaryHeap<int>();

            foreach (var item in paramCollection)
            {
                maximumHeap.Add(item);
            }

            var actual = new List<int>(paramCollection.Count);
            actual.AddRange(Enumerable.Range(1, paramCollection.Count).Select(item => maximumHeap.GetMaxumum()));

            Assert.That(actual, MoreThan.Sorted<int>((x, y) => y.CompareTo(x)));
            Assert.That(actual, Is.EqualTo(expected));
        }

    }
}
