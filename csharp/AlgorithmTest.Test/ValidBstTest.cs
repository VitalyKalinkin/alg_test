
using NUnit.Framework;

namespace AlgorithmTest.Test
{
    [TestFixture]
    public class ValidBstTest
    {
        [Test]
        public void ValidBst()
        {
            var root = new BinaryTreeNode<int, int>(50, 50)
            {
                Left = new BinaryTreeNode<int, int>(40, 40)
                {
                    Left = new BinaryTreeNode<int, int>(30, 30)
                    {
                        Left = new BinaryTreeNode<int, int>(20, 20),
                        Right = new BinaryTreeNode<int, int>(35, 35)
                    },
                    Right = new BinaryTreeNode<int, int>(45, 45)
                    {
                        Left = new BinaryTreeNode<int, int>(42, 42),
                        Right = new BinaryTreeNode<int, int>(49, 49)
                    }
                },
                Right = new BinaryTreeNode<int, int>(60, 60)
                {
                    Left = new BinaryTreeNode<int, int>(55, 55)
                    {
                        Left = new BinaryTreeNode<int, int>(51, 51),
                        Right = new BinaryTreeNode<int, int>(58, 58)
                    },
                    Right = new BinaryTreeNode<int, int>(70, 70)
                    {
                        Left = new BinaryTreeNode<int, int>(63, 63),
                        Right = new BinaryTreeNode<int, int>(71, 71)
                    }
                }
            };

            Assert.That(root.IsValidBst(), Is.True);
        }

        [Test]
        public void UnbalancedValidBst()
        {
            var root = new BinaryTreeNode<int, int>(50, 50)
            {
                Left = new BinaryTreeNode<int, int>(40, 40)
                {
                    Left = new BinaryTreeNode<int, int>(30, 30)
                    {
                        Left = new BinaryTreeNode<int, int>(20, 20),
                        Right = new BinaryTreeNode<int, int>(35, 35)
                    },
                    Right = new BinaryTreeNode<int, int>(45, 45)
                    {
                        Left = new BinaryTreeNode<int, int>(42, 42),
                        Right = new BinaryTreeNode<int, int>(49, 49)
                    }
                },
                Right = new BinaryTreeNode<int, int>(60, 60)
            };

            Assert.That(root.IsValidBst(), Is.True);
        }

        [Test]
        public void UnbalancedValidBst2()
        {
            var root = new BinaryTreeNode<int, int>(50, 50)
            {
                Left = new BinaryTreeNode<int, int>(40, 40),
                Right = new BinaryTreeNode<int, int>(60, 60)
                {
                    Left = new BinaryTreeNode<int, int>(55, 55)
                    {
                        Left = new BinaryTreeNode<int, int>(51, 51),
                        Right = new BinaryTreeNode<int, int>(58, 58)
                    },
                    Right = new BinaryTreeNode<int, int>(70, 70)
                    {
                        Left = new BinaryTreeNode<int, int>(63, 63),
                        Right = new BinaryTreeNode<int, int>(71, 71)
                    }
                }
            };

            Assert.That(root.IsValidBst(), Is.True);
        }

        [Test]
        public void NotValidBst()
        {
            var root = new BinaryTreeNode<int, int>(50, 50)
            {
                Left = new BinaryTreeNode<int, int>(40, 40)
                {
                    Left = new BinaryTreeNode<int, int>(30, 30)
                    {
                        Left = new BinaryTreeNode<int, int>(20, 20),
                        Right = new BinaryTreeNode<int, int>(35, 35)
                    },
                    Right = new BinaryTreeNode<int, int>(45, 45)
                    {
                        Left = new BinaryTreeNode<int, int>(42, 42),
                        Right = new BinaryTreeNode<int, int>(49, 49)
                    }
                },
                Right = new BinaryTreeNode<int, int>(60, 60)
                {
                    Left = new BinaryTreeNode<int, int>(55, 55)
                    {
                        Left = new BinaryTreeNode<int, int>(51, 51),
                        Right = new BinaryTreeNode<int, int>(58, 58)
                    },
                    Right = new BinaryTreeNode<int, int>(70, 70)
                    {
                        Left = new BinaryTreeNode<int, int>(70, 70),
                        Right = new BinaryTreeNode<int, int>(71, 71)
                    }
                }
            };

            Assert.That(root.IsValidBst(), Is.False);
        }
    }
}
