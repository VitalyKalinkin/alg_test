using System.Collections.Generic;
using NUnit.Framework;

namespace AlgorithmTest.Test
{
    [TestFixture]
    public class MergeSortTest
    {
        [Test]
        public void SimpleCase()
        {
            var result = MergeSort.Sort(new List<int> {4, 7, 1, 6}, (x, y) => x.CompareTo(y));
            Assert.That(result, MoreIs.Sorted<int>());
        }
    }
}
