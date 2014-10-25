using NUnit.Framework;

namespace AlgorithmTest.Test
{
    [TestFixture]
    class MoreIsTest
    {
        [Test]
        public void SortedArray()
        {
            Assert.That(new[] {1, 2, 3}, MoreIs.Sorted<int>());
        }

        [Test]
        public void UnsortedArray()
        {
            Assert.That(MoreIs.Sorted<int>().Resolve().Matches(new[] { 1, 3, 2 }), Is.False);
        }
    }
}
