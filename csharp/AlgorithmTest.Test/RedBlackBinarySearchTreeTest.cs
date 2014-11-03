
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AlgorithmTest.Test
{
    [TestFixture]
    public class RedBlackBinarySearchTreeTest
    {
        [Test]
        public void SimpleSearch()
        {
            var tree = new RedBlackBinarySearchTree<int, int>();

            foreach (var item in Enumerable.Range(0, 100000))
            {
                tree.Add(item, item * 2);
            }

            foreach (var expected in Enumerable.Range(0, 100000))
            {
                Assert.That(tree.ExactSearch(expected), Is.EqualTo(expected * 2));
            }

            foreach (var expected in Enumerable.Range(100001, 200000))
            {
                Assert.That(tree.ExactSearch(expected), Is.EqualTo(0));
            }
        }

        [Test]
        public void MimimumGreaterValue()
        {
            var tree = new RedBlackBinarySearchTree<int, int>();

            foreach (var item in Enumerable.Range(0, 100000).Where(x => x % 2 == 0))
            {
                tree.Add(item, item * 2);
            }

            foreach (var expected in Enumerable.Range(0, 100000 - 1))
            {
                var actual = tree.MinimumGreaterOrEqual(expected);
                Assert.That(actual, Is.EqualTo(expected % 2 == 0 ? expected : expected + 1));
            }

            Assert.That(tree.MinimumGreaterOrEqual(100000), Is.EqualTo(0));
        }

        [Test]
        public void MaximumLesserValue()
        {
            var tree = new RedBlackBinarySearchTree<int, int>();

            foreach (var item in Enumerable.Range(0, 100000).Where(x => x % 2 == 0))
            {
                tree.Add(item, item * 2);
            }

            foreach (var expected in Enumerable.Range(0, 100000))
            {
                var actual = tree.MaximumLesserOrEqual(expected);
                Assert.That(actual, Is.EqualTo(expected % 2 == 0 ? expected : expected - 1));
            }

            Assert.That(tree.MaximumLesserOrEqual(-1), Is.EqualTo(0));
        }

        [Test]
        public void NextValue()
        {
            var tree = new RedBlackBinarySearchTree<int, int>();

            foreach (var item in Enumerable.Range(0, 100000))
            {
                tree.Add(item, item * 2);
            }

            foreach (var expected in Enumerable.Range(0, 100000 - 1))
            {
                var actual = tree.NextKey(expected);
                Assert.That(actual, Is.EqualTo(expected + 1));
            }

            Assert.That(tree.NextKey(100000), Is.EqualTo(0));
        }

        [Test]
        public void PrevValue()
        {
            var tree = new RedBlackBinarySearchTree<int, int>();

            foreach (var item in Enumerable.Range(0, 100000))
            {
                tree.Add(item, item * 2);
            }

            foreach (var expected in Enumerable.Range(1, 100000))
            {
                var actual = tree.PrevKey(expected);
                Assert.That(actual, Is.EqualTo(expected - 1));
            }

            Assert.That(tree.PrevKey(0), Is.EqualTo(0));
        }

        [Test]
        public void Size()
        {
            var tree = new RedBlackBinarySearchTree<int, int>();

            foreach (var item in Enumerable.Range(0, 100000))
            {
                tree.Add(item, item * 2);
            }

            Assert.That(tree.Size(), Is.EqualTo(100000));
        }

        [Test]
        public void Rank()
        {
            var tree = new RedBlackBinarySearchTree<int, int>();

            foreach (var item in Enumerable.Range(0, 100000))
            {
                tree.Add(item, item * 2);
            }

            foreach (var expected in Enumerable.Range(1, 100000))
            {
                var actual = tree.Rank(expected);
                Assert.That(actual, Is.EqualTo(expected));
            }

            Assert.That(tree.Rank(100001), Is.EqualTo(100000));
            Assert.That(tree.Rank(-1), Is.EqualTo(0));
        }

        [Test]
        public void SelectNth()
        {
            var tree = new RedBlackBinarySearchTree<int, int>();

            foreach (var item in Enumerable.Range(0, 100000))
            {
                tree.Add(item, item * 2);
            }

            foreach (var expected in Enumerable.Range(0, 100000))
            {
                var actual = tree.SelectNth(expected);
                Assert.That(actual, Is.EqualTo(expected));
            }

            Assert.That(tree.SelectNth(100001), Is.EqualTo(0));
        }

        [Test]
        public void TraverseKeys()
        {
            var tree = new RedBlackBinarySearchTree<int, int>();

            foreach (var item in Enumerable.Range(0, 100000))
            {
                tree.Add(item, item * 2);
            }

            var actual = tree.TraverseKeys();
            Assert.That(actual, Is.EqualTo(Enumerable.Range(0, 100000)));
        }
    }
}
