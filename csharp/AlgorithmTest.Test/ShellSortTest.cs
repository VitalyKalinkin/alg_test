using System.Collections.Generic;
using NUnit.Framework;

namespace AlgorithmTest.Test
{
    [TestFixture]
    public class ShellSortTest : SortingTest
    {
        private static readonly int[][] ToSort = ToSortBase;

        [TestCaseSource("ToSort")]
        public void SimpleCases(ICollection<int> paramCollection)
        {
            var result = ShellSort.Sort(paramCollection);
            Assert.That(result, MoreThan.Sorted<int>());
        }
    }
}