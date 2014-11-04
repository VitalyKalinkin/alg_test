
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AlgorithmTest.Test
{
    [TestFixture]
    public class BinarySearchTreeTest
    {
        [Test]
        public void SimpleSearch()
        {
            var tree = new BinarySearchTree<int, int>();

            foreach (var item in Enumerable.Range(0, 100000).ToList().Shuffle())
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
            var tree = new BinarySearchTree<int, int>();

            foreach (var item in Enumerable.Range(0, 100000).Where(x => x % 2 == 0).ToList().Shuffle())
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
            var tree = new BinarySearchTree<int, int>();

            foreach (var item in Enumerable.Range(0, 100000).Where(x => x % 2 == 0).ToList().Shuffle())
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
            var tree = new BinarySearchTree<int, int>();

            foreach (var item in Enumerable.Range(0, 100000).ToList().Shuffle())
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
            var tree = new BinarySearchTree<int, int>();

            foreach (var item in Enumerable.Range(0, 100000).ToList().Shuffle())
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
            var tree = new BinarySearchTree<int, int>();

            foreach (var item in Enumerable.Range(0, 100000).ToList().Shuffle())
            {
                tree.Add(item, item * 2);
            }

            Assert.That(tree.Size(), Is.EqualTo(100000));
        }

        [Test]
        public void Rank()
        {
            var tree = new BinarySearchTree<int, int>();

            foreach (var item in Enumerable.Range(0, 100000).ToList().Shuffle())
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
            var tree = new BinarySearchTree<int, int>();

            foreach (var item in Enumerable.Range(0, 100000).ToList().Shuffle())
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
            var tree = new BinarySearchTree<int, int>();

            foreach (var item in Enumerable.Range(0, 100000).ToList().Shuffle())
            {
                tree.Add(item, item * 2);
            }

            var actual = tree.TraverseKeys();
            Assert.That(actual, Is.EqualTo(Enumerable.Range(0, 100000)));
        }

        [Test]
        public void DeleteMin()
        {
            var tree = new BinarySearchTree<int, int>();

            foreach (var item in Enumerable.Range(0, 100000).ToList().Shuffle())
            {
                tree.Add(item, item * 2);
            }

            foreach (var expected in Enumerable.Range(0, 100000))
            {
                tree.DeleteMin();
                Assert.That(tree.ExactSearch(expected), Is.EqualTo(0));
                Assert.That(tree.Size(), Is.EqualTo(100000 - expected - 1));
            }

            Assert.That(tree.Size(), Is.EqualTo(0));
        }

        [Test]
        public void Delete()
        {
            var tree = new BinarySearchTree<int, int>();

            foreach (var item in Enumerable.Range(0, 100000).ToList().Shuffle())
            {
                tree.Add(item, item * 2);
            }

            var index = 1;
            var removed = new List<int>();
            foreach (var expected in Enumerable.Range(0, 10000).ToList().Shuffle())
            {
                tree.Delete(expected);
                Assert.That(tree.ExactSearch(expected), Is.EqualTo(0));
                Assert.That(tree.Size(), Is.EqualTo(100000 - index++));
                removed.Add(expected);
            }

            Assert.That(tree.Size(), Is.EqualTo(90000));

            Assert.That(tree.TraverseKeys(), Is.EqualTo(Enumerable.Range(0, 100000).Except(removed)));
        }

        [Test]
        public void Range()
        {
            var tree = new BinarySearchTree<int, int>();

            foreach (var item in Enumerable.Range(0, 100000).ToList().Shuffle())
            {
                tree.Add(item, item * 2);
            }

            var random = new Random();
            for (var i = 0; i < 100; i++)
            {
                var firstKey = random.Next(0, 100000);
                var secondKey = random.Next(firstKey + 1, 100000);

                var range = tree.Range(firstKey, secondKey);

                Assert.That(range, Is.EqualTo(Enumerable.Range(firstKey, secondKey - firstKey + 1)));
            }
        }
    }
}
