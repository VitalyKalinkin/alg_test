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
            var graph = new Graph<int>();
            var node0 = new GraphNode<int>(0);
            var node1 = new GraphNode<int>(1);
            var node2 = new GraphNode<int>(2);
            var node3 = new GraphNode<int>(3);
            var node4 = new GraphNode<int>(4);
            var node5 = new GraphNode<int>(5);
            var node6 = new GraphNode<int>(6);

            node0.AddAdjuscent(node1);
            node0.AddAdjuscent(node2);
            node0.AddAdjuscent(node3);

            node1.AddAdjuscent(node5);
            node2.AddAdjuscent(node4);

            node3.AddAdjuscent(node6);

            node4.AddAdjuscent(node1);

            graph.AddNode(node0);
            graph.AddNode(node1);
            graph.AddNode(node2);
            graph.AddNode(node3);
            graph.AddNode(node4);
            graph.AddNode(node5);
            graph.AddNode(node6);

            var actual = GraphBipartator.Bipartite(graph);
            Assert.That(new HashSet<GraphNode<int>>(actual.Item1), Is.EqualTo(new HashSet<GraphNode<int>> { node0, node5, node4, node6}));
            Assert.That(new HashSet<GraphNode<int>>(actual.Item2), Is.EqualTo(new HashSet<GraphNode<int>>{node1, node2, node3}));
        }

        [Test]
        public void NotPartitibleGraph()
        {
            var graph = new Graph<int>();
            var node0 = new GraphNode<int>(0);
            var node1 = new GraphNode<int>(1);
            var node2 = new GraphNode<int>(2);
            var node3 = new GraphNode<int>(3);
            var node4 = new GraphNode<int>(4);
            var node5 = new GraphNode<int>(5);
            var node6 = new GraphNode<int>(6);

            node0.AddAdjuscent(node1);
            node0.AddAdjuscent(node2);
            node0.AddAdjuscent(node3);

            node1.AddAdjuscent(node5);
            node2.AddAdjuscent(node4);

            node3.AddAdjuscent(node6);

            node4.AddAdjuscent(node1);

            node5.AddAdjuscent(node0);

            graph.AddNode(node0);
            graph.AddNode(node1);
            graph.AddNode(node2);
            graph.AddNode(node3);
            graph.AddNode(node4);
            graph.AddNode(node5);
            graph.AddNode(node6);

            Assert.That(() => GraphBipartator.Bipartite(graph), Throws.Exception.InstanceOf<InvalidDataException>());
        }
    }
}
