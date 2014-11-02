using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmTest
{
    public static class Extentions
    {
        public static IEnumerable<T> Clone<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Select(x => x);
        }

        public static void Swap<T>(this IList<T> list, int i, int j)
        {
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        public static IList<T> Shuffle<T>(this IList<T> source)
        {
            var rand = new Random();
            for (var i = 0; i < source.Count; ++i)
            {
                source.Swap(i, rand.Next(i, source.Count));
            }

            return source;
        }

        public static SingleLinkedListNode<T> GetNthNode<T>(this SingleLinkedListNode<T> head, int n)
        {
            var currentNode = head;
            for (var i = 0; i < n && currentNode != null; i++)
            {
                currentNode = currentNode.NextNode;
            }

            return currentNode;
        }

        public static SingleLinkedListNode<T> GetTail<T>(this SingleLinkedListNode<T> head)
        {
            var currentNode = head;
            while (currentNode.NextNode != null)
                currentNode = currentNode.NextNode;

            return currentNode;
        }

        public static bool IsValidBst<T>(this BinaryTreeNode<int, T> root)
        {
            return IsValidBstRec(root, int.MinValue, int.MaxValue);
        }

        private static bool IsValidBstRec<T>(BinaryTreeNode<int, T> root, int minValue, int maxValue)
        {
            if (root == null)
                return true;

            return root.Key > minValue
                   && root.Key < maxValue
                   && IsValidBstRec(root.Left, minValue, root.Key)
                   && IsValidBstRec(root.Right, root.Key, maxValue);
        }
    }
}
