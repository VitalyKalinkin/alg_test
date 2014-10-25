using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AlgorithmTest.Test
{
    [TestFixture]
    public class ShellSortTest : SortingTest
    {
        private static readonly int[][] ToSort = ToSortBase;

        [TestCaseSource("ToSort")]
        public void SimpleCases(IList<int> paramCollection)
        {
            var result = ShellSort.Sort(paramCollection.Clone().ToList());
            Assert.That(result, MoreThan.Sorted<int>());
        }
    }
}