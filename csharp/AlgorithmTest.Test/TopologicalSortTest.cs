using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AlgorithmTest.Test
{
    [TestFixture]
    public class TopologicalSortTest
    {
        [Test]
        public void Sort()
        {
            var g = GraphConstractor.Construct(new Dictionary<int, IEnumerable<int>>
            {
                {0, new[] {1, 5}},
                {1, new int[0] },
                {2, new[] {0, 3}},
                {3, new[] {5}},
                {4, new int[] {}},
                {5, new[] {4}},
                {6, new[] {0, 4, 9}},
                {7, new[] {6}},
                {8, new[] {7}},
                {9, new[] {10, 11, 12}},
                {10, new int[] {}},
                {11, new[] {12}},
                {12, new int[] {}},
            });

            var actual = TopologicalSort.TopologicallySort(g).ToList();
            Assert.That(actual, MoreThan.InTopologicalOrder(g));
            Assert.That(actual.Count, Is.EqualTo(g.Nodes.Count()));
        }
    }
}