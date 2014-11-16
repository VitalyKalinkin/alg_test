using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace AlgorithmTest.Test
{

    [TestFixture]
    public class GraphBipartatorTest
    {
        [Test]
        public void PartitibleGraph()
        {
            var g = GraphConstractor.Construct(new Dictionary<int, IEnumerable<int>>
            {
                {0, new[] {1, 2, 3}},
                {1, new[] {5}},
                {2, new[] {4}},
                {3, new[] {6}},
                {4, new[] {1}},
                {5, new int[] {}},
                {6, new int[] {}},
            });

            var actual = GraphBipartator.Bipartite(g);
            Assert.That(actual.Item1, Is.EquivalentTo(new[] {g[0], g[5], g[6], g[4]}));
            Assert.That(actual.Item2, Is.EquivalentTo(new[] {g[1], g[2], g[3]}));
        }

        [Test]
        public void NotPartitibleGraph()
        {
            var g = GraphConstractor.Construct(new Dictionary<int, IEnumerable<int>>
            {
                {0, new[] {1, 2, 3}},
                {1, new[] {5}},
                {2, new[] {4}},
                {3, new[] {6}},
                {4, new[] {1}},
                {5, new[] {0}},
                {6, new int[] {}},
            });

            Assert.That(() => GraphBipartator.Bipartite(g), Throws.Exception.InstanceOf<InvalidDataException>());
        }
    }
}
