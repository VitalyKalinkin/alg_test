namespace AlgorithmTest
{
    public static class LinkedListCycleDetector
    {
        public static SingleLinkedListNode<T> GetFirstCycleItem<T>(SingleLinkedListNode<T> head)
        {
            var slow = head;
            var fast = head;

            do
            {
                if (slow.NextNode == null || fast.NextNode == null || fast.NextNode.NextNode == null)
                {
                    return null;
                }

                slow = slow.NextNode;
                fast = fast.NextNode.NextNode;
            } while (slow != fast);

            return FindExactCycleStartNode(slow, head);
        }

        private static SingleLinkedListNode<T> FindExactCycleStartNode<T>(SingleLinkedListNode<T> meetPoint, SingleLinkedListNode<T> head)
        {
            var cycleLength = 0;

            var movingPoint = meetPoint;

            // Finds cycle length.
            do
            {
                movingPoint = movingPoint.NextNode;
                cycleLength++;
            } while (movingPoint != meetPoint);

            // Sets the long pointer to the Kth node, where k is the cycle length.
            var longPointer = head;

            for (var i = 0; i < cycleLength; ++i)
            {
                longPointer = longPointer.NextNode;
            }

            // Moving both pointer together unless they meet. This way they point to the cycle start.
            // Since it is Kth node from the "end".
            var shortPointer = head;

            while (longPointer != shortPointer)
            {
                longPointer = longPointer.NextNode;
                shortPointer = shortPointer.NextNode;
            }

            return longPointer;
        }
    }
}
