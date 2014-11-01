using System.Linq;
using NUnit.Framework;

namespace AlgorithmTest.Test
{
    [TestFixture]
    public class DepthFirstSearchTest
    {
        [Test]
        public void FourLevelPath()
        {
            var root = GenerateTree();
            var actualPath = DepthFirstSearch.GetPathToNode(root, 7);
            Assert.That(string.Join("->", actualPath.Select(x => x.Payload)), Is.EqualTo("0->1->5->7"));
        }

        [Test]
        public void OneLevelPath()
        {
            var root = GenerateTree();
            var actualPath = DepthFirstSearch.GetPathToNode(root, 0);
            Assert.That(string.Join("->", actualPath.Select(x => x.Payload)), Is.EqualTo("0"));
        }

        [Test]
        public void ThreeLevelPath()
        {
            var root = GenerateTree();
            var actualPath = DepthFirstSearch.GetPathToNode(root, 5);
            Assert.That(string.Join("->", actualPath.Select(x => x.Payload)), Is.EqualTo("0->1->5"));
        }

        [Test]
        public void NoResult()
        {
            var root = GenerateTree();
            var actualPath = DepthFirstSearch.GetPathToNode(root, 100500);
            Assert.That(string.Join("->", actualPath.Select(x => x.Payload)), Is.EqualTo(""));
        }

        private static GeneralTreeNode<int> GenerateTree()
        {
            return new GeneralTreeNode<int>(0, new[]
            {
                new GeneralTreeNode<int>(1, new[]
                {
                    new GeneralTreeNode<int>(4), 
                    new GeneralTreeNode<int>(5, new[]
                    {
                        new GeneralTreeNode<int>(6), 
                        new GeneralTreeNode<int>(7)
                    }), 
                }),
                new GeneralTreeNode<int>(2, new[]
                {
                    new GeneralTreeNode<int>(8) 
                }), 
                new GeneralTreeNode<int>(3) 
            });
        }
    }
}
