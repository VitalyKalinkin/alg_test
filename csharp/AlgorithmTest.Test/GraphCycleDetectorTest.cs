using System.Collections.Generic;
using NUnit.Framework;

namespace AlgorithmTest.Test
{
    [TestFixture]
    public class GraphCycleDetectorTest
    {
        [Test]
        public void OneCycle()
        {
            var g = GraphConstractor.Construct(new Dictionary<int, IEnumerable<int>>
            {
                {0, new[] {1, 5}},
                {1, new int[0] },
                {2, new[] {0, 3}},
                {3, new[] {2, 5}},
                {4, new[] {2, 3}},
                {5, new[] {4}},
                {6, new[] {0, 4, 9}},
                {7, new[] {6, 8}},
                {8, new[] {7, 9}},
                {9, new[] {10, 11}},
                {10, new[] {12}},
                {11, new[] {12}},
                {12, new[] {9}},
            });

            Assert.That(GraphCycleDetector.DetectCycle(g), Is.EquivalentTo(new[] {g[4], g[5], g[0], g[2]}));
        }

        [Test]
        public void NoCycle()
        {
            var g = GraphConstractor.Construct(new Dictionary<int, IEnumerable<int>>
            {
                {0, new[] {1, 5}},
                {1, new int[0] },
                {2, new int[] {}},
                {3, new[] {2, 5}},
                {4, new[] {2}},
                {5, new[] {4}},
                {6, new[] {0, 4, 9}},
                {7, new[] {6, 8}},
                {8, new[] {9}},
                {9, new[] {10, 11}},
                {10, new int[] {}},
                {11, new int[] {}},
                {12, new[] {9}},
            });

            Assert.That(GraphCycleDetector.DetectCycle(g), Is.Empty);
        }
    }
}