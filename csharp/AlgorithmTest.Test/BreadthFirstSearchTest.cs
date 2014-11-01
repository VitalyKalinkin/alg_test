using System.Linq;
using NUnit.Framework;

namespace AlgorithmTest.Test
{
    [TestFixture]
    public class BreadthFirstSearchTest
    {
        [Test]
        public void SimpleTree()
        {
            var root = GenerateTree();
            var actualLevels = BreadthFirstSearch<int>.SplitByLevels(root);
            Assert.That(actualLevels.Select(x => string.Join(",", x.Select(y => y.Payload))),
                Is.EqualTo(new[] {"0", "1,2,3", "4,5,8", "6,7"}));
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
