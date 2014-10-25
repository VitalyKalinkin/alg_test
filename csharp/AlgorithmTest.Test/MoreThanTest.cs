using NUnit.Framework;

namespace AlgorithmTest.Test
{
    [TestFixture]
    class MoreThanTest
    {
        [Test]
        public void SortedArray()
        {
            Assert.That(new[] {1, 2, 3}, MoreThan.Sorted<int>());
        }

        [Test]
        public void SortedArrayReversedComparer()
        {
            Assert.That(new[] { 3, 2, 1 }, MoreThan.Sorted<int>((x, y) => y.CompareTo(x)));
        }

        [Test]
        public void TwoItemArray()
        {
            Assert.That(new[] { 1, 2 }, MoreThan.Sorted<int>());
        }

        [Test]
        public void OneItemArray()
        {
            Assert.That(new[] { 1 }, MoreThan.Sorted<int>());
        }

        [Test]
        public void EmptyArray()
        {
            Assert.That(new int[0], MoreThan.Sorted<int>());
        }

        [Test]
        public void ArrayWithDuplicates()
        {
            Assert.That(new[] { 1, 2, 2, 3 }, MoreThan.Sorted<int>());
        }

        [Test]
        public void ArrayWithDuplicatesReversedComparer()
        {
            Assert.That(new[] { 3, 2, 2, 1 }, MoreThan.Sorted<int>((x, y) => y.CompareTo(x)));
        }

        [Test]
        public void UnsortedArray()
        {
            Assert.That(MoreThan.Sorted<int>().Resolve().Matches(new[] { 1, 3, 2 }), Is.False);
        }

        [Test]
        public void TwoItemUnsorted()
        {
            Assert.That(MoreThan.Sorted<int>().Resolve().Matches(new[] { 3, 1 }), Is.False);
        }

        [Test]
        public void UnsortedArrayReversedComparer()
        {
            Assert.That(MoreThan.Sorted<int>((x, y) => y.CompareTo(x)).Resolve().Matches(new[] { 1, 3, 2 }), Is.False);
        }

        [Test]
        public void ArrayWithDuplicatesRevesedComparer()
        {
            Assert.That(MoreThan.Sorted<int>((x, y) => y.CompareTo(x)).Resolve().Matches(new[] { 1, 2, 2, 3 }), Is.False);
        }
    }
}
