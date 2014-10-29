using System.Data;
using System.Linq;
using NUnit.Framework;

namespace AlgorithmTest.Test
{
    [TestFixture]
    public class LinkedListCycleDetectorTest
    {
        [Test]
        public void FullOddCycle()
        {
            var head = SingleLinkedListNode<int>.NewBuilder()
                .AddNodes(new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11})
                .Build();

            var tail = head.GetTail();
            tail.NextNode = head;

            var actual = LinkedListCycleDetector.GetFirstCycleItem(head);

            Assert.That(actual, Is.EqualTo(head));
        }

        [Test]
        public void FullEvenCycle()
        {
            var head = SingleLinkedListNode<int>.NewBuilder()
                .AddNodes(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })
                .Build();

            var tail = head.GetTail();
            tail.NextNode = head;

            var actual = LinkedListCycleDetector.GetFirstCycleItem(head);

            Assert.That(actual, Is.EqualTo(head));
        }

        [Test]
        public void NotFullEvenCycle()
        {
            var head = SingleLinkedListNode<int>.NewBuilder()
                .AddNodes(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })
                .Build();

            var cycleHead = head.GetNthNode(4);
            var tail = head.GetTail();

            tail.NextNode = cycleHead;

            var actual = LinkedListCycleDetector.GetFirstCycleItem(head);

            Assert.That(actual, Is.EqualTo(cycleHead));
        }

        [Test]
        public void NotFullOddCycle()
        {
            var head = SingleLinkedListNode<int>.NewBuilder()
                .AddNodes(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 })
                .Build();

            var cycleHead = head.GetNthNode(4);
            var tail = head.GetTail();

            tail.NextNode = cycleHead;

            var actual = LinkedListCycleDetector.GetFirstCycleItem(head);

            Assert.That(actual, Is.EqualTo(cycleHead));
        }

        [Test]
        public void CycleMoreThenCycleLengthFromTheStart()
        {
            var head = SingleLinkedListNode<int>.NewBuilder()
                .AddNodes(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })
                .Build();

            var cycleHead = head.GetNthNode(7);
            var tail = head.GetTail();

            tail.NextNode = cycleHead;

            var actual = LinkedListCycleDetector.GetFirstCycleItem(head);

            Assert.That(actual, Is.EqualTo(cycleHead));
        }

        [Test]
        public void NoCycle()
        {
            var head = SingleLinkedListNode<int>.NewBuilder()
                .AddNodes(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })
                .Build();

            var actual = LinkedListCycleDetector.GetFirstCycleItem(head);

            Assert.That(actual, Is.Null);
        }

        [Test]
        public void NoCycleOneItem()
        {
            var head = SingleLinkedListNode<int>.NewBuilder()
                .AddNodes(new[] { 0 })
                .Build();

            var actual = LinkedListCycleDetector.GetFirstCycleItem(head);

            Assert.That(actual, Is.Null);
        }

        [Test]
        public void FullCycleOneItem()
        {
            var head = SingleLinkedListNode<int>.NewBuilder()
                .AddNodes(new[] { 0 })
                .Build();

            var tail = head.GetTail();
            tail.NextNode = head;

            var actual = LinkedListCycleDetector.GetFirstCycleItem(head);

            Assert.That(actual, Is.EqualTo(head));
        }

        [Test]
        public void NotFullCycleOneItem()
        {
            var head = SingleLinkedListNode<int>.NewBuilder()
                .AddNodes(new[] { 0, 1 })
                .Build();

            var cycleHead = head.GetNthNode(1);
            var tail = head.GetTail();
            tail.NextNode = cycleHead;

            var actual = LinkedListCycleDetector.GetFirstCycleItem(head);

            Assert.That(actual, Is.EqualTo(cycleHead));
        }

        [Test]
        public void VeryLongCycle()
        {
            var head = SingleLinkedListNode<int>.NewBuilder()
               .AddNodes(Enumerable.Range(0, 1005000))
               .Build();

            var cycleHead = head.GetNthNode(1);
            var tail = head.GetTail();
            tail.NextNode = cycleHead;

            var actual = LinkedListCycleDetector.GetFirstCycleItem(head);

            Assert.That(actual, Is.EqualTo(cycleHead));
        }

        [Test]
        public void VeryLongHeadWithCycle()
        {
            var head = SingleLinkedListNode<int>.NewBuilder()
               .AddNodes(Enumerable.Range(0, 1005000))
               .Build();

            var cycleHead = head.GetNthNode(1005000 - 1);
            var tail = head.GetTail();
            tail.NextNode = cycleHead;

            var actual = LinkedListCycleDetector.GetFirstCycleItem(head);

            Assert.That(actual, Is.EqualTo(cycleHead));
        }

        [Test]
        public void VeryLongListWithoutCycle()
        {
            var head = SingleLinkedListNode<int>.NewBuilder()
               .AddNodes(Enumerable.Range(0, 1005000))
               .Build();

            var actual = LinkedListCycleDetector.GetFirstCycleItem(head);

            Assert.That(actual, Is.Null);
        }
    }
}