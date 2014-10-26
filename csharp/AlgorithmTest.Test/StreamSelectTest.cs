using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AlgorithmTest.Test
{
    [TestFixture]
    public class StreamSelect : SortingTest
    {
        private static readonly int[][] ToSort = ToSortBase;
        private static readonly int[][] ToReallyHardSortWork = ToReallyHardSortWorkBase;

        [TestCaseSource("ToSort")]
        public void SimpleCases(IList<int> paramCollection)
        {
            int k = paramCollection.Count/2;
            var expectedResult = MergeSort.Sort(paramCollection.Clone().ToList());
            var actualResult = StreamSelection.Select(paramCollection.Clone().ToList(), k);
            Assert.That(actualResult, Is.EqualTo(expectedResult[k]));
        }

        [TestCaseSource("ToReallyHardSortWork")]
        public void HeavyCases(IList<int> paramCollection)
        {
            int k = paramCollection.Count / 1000;
            var expectedResult = MergeSort.Sort(paramCollection.Clone().ToList());
            var actualResult = StreamSelection.Select(paramCollection.Clone().ToList(), k);
            Assert.That(actualResult, Is.EqualTo(expectedResult[k]));
        }
    }
}