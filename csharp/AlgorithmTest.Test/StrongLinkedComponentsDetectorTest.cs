using System.Collections.Generic;
using NUnit.Framework;

namespace AlgorithmTest.Test
{
    [TestFixture]
    public class StrongLinkedComponentsDetectorTest
    {
        [Test]
        public void Detect()
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

            var actual = StrongLinkedComponentsDetector.DetectStrongLinkedComponents(g);
            Assert.That(actual, Is.EquivalentTo(new[]
            {
                new[] {g[0], g[5], g[4], g[2], g[3]},
                new[] {g[1]},
                new[] {g[6]},
                new[] {g[7], g[8]},
                new[] {g[9], g[10], g[11], g[12]},
            }));
        }
    }
}