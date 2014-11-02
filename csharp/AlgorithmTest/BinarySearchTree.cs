using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;

namespace AlgorithmTest
{
    public class BinarySearchTree<K, T> where K : IComparable<K>
    {
        private BinaryTreeNode<K, T> _root;

        public void Add(K key, T value)
        {
            _root = AddRecusive(_root, key, value);
        }

        private static BinaryTreeNode<K, T> AddRecusive(BinaryTreeNode<K, T> rootNode, K key, T value)
        {
            if (rootNode == null)
                return new BinaryTreeNode<K, T>(key, value) {Size = 1};

            if (rootNode.Key.CompareTo(key) < 0)
            {
                rootNode.Right = AddRecusive(rootNode.Right, key, value);
            }
            else if (rootNode.Key.CompareTo(key) > 0)
            {
                rootNode.Left = AddRecusive(rootNode.Left, key, value);
            }
            else
            {
                return new BinaryTreeNode<K, T>(key, value) { Left = rootNode.Left, Right = rootNode.Right, Size = rootNode.Size};
            }

            rootNode.Size = 1 + Size(rootNode.Left) + Size(rootNode.Right);
            return rootNode;
        }

        public T ExactSearch(K key)
        {
            var currentNode = _root;

            while (currentNode != null)
            {
                var cmp = currentNode.Key.CompareTo(key);

                if (cmp < 0)
                {
                    currentNode = currentNode.Right;
                }
                else if (cmp > 0)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    return currentNode.Payload;
                }
            }

            return default(T);
        }

        public K MinimumGreaterOrEqual(K key)
        {
            var result = MimimumGreaterOrEqualRecusive(_root, key);
            return result == null ? default(K) : result.Key;
        }

        private static BinaryTreeNode<K, T> MimimumGreaterOrEqualRecusive(BinaryTreeNode<K, T> root, K key)
        {
            if (root == null)
                return null;

            var cmp = key.CompareTo(root.Key);

            if (cmp > 0)
                return MimimumGreaterOrEqualRecusive(root.Right, key);
            
            if (cmp == 0)
                return root;

            var leftResult = MimimumGreaterOrEqualRecusive(root.Left, key);

            return leftResult ?? root;
        }

        public K MaximumLesserOrEqual(K key)
        {
            var result = MaximumLesserOrEqualRecursive(_root, key);
            return result == null ? default(K) : result.Key;
        }

        private static BinaryTreeNode<K, T> MaximumLesserOrEqualRecursive(BinaryTreeNode<K, T> root, K key)
        {
            if (root == null)
                return null;

            var cmp = key.CompareTo(root.Key);

            if (cmp < 0)
                return MaximumLesserOrEqualRecursive(root.Left, key);

            if (cmp == 0)
                return root;

            var rightResult = MaximumLesserOrEqualRecursive(root.Right, key);
            return rightResult ?? root;
        }

        public K NextKey(K key)
        {
            var result = NextKeyRecursive(_root, key);
            return result == null ? default(K) : result.Key;
        }

        private static BinaryTreeNode<K, T> NextKeyRecursive(BinaryTreeNode<K, T> root, K key)
        {
            if (root == null)
                return null;

            var cmp = key.CompareTo(root.Key);

            if (cmp >= 0)
            {
                return NextKeyRecursive(root.Right, key);
            }

            var leftResult = NextKeyRecursive(root.Left, key);
            return leftResult ?? root;
        }

        public K PrevKey(K key)
        {
            var result = PrevKeyRecursive(_root, key);
            return result == null ? default(K) : result.Key;
        }

        private static BinaryTreeNode<K, T> PrevKeyRecursive(BinaryTreeNode<K, T> root, K key)
        {
            if (root == null)
                return null;

            var cmp = key.CompareTo(root.Key);

            if (cmp <= 0)
            {
                return PrevKeyRecursive(root.Left, key);
            }

            var rightResult = PrevKeyRecursive(root.Right, key);
            return rightResult ?? root;
        }

        public int Size()
        {
            return Size(_root);
        }

        private static int Size(BinaryTreeNode<K, T> root)
        {
            return root == null ? 0 : root.Size;
        }

        public int Rank(K key)
        {
            // Number of keys less than key.
            return Rank(_root, key);
        }

        private static int Rank(BinaryTreeNode<K, T> root, K key)
        {
            if (root == null)
                return 0;

            var cmp = key.CompareTo(root.Key);

            if (cmp < 0)
                return Rank(root.Left, key);
            if (cmp > 0)
                return 1 + Size(root.Left) + Rank(root.Right, key);
            return Size(root.Left);
        }

        public K SelectNth(int index)
        {
            var result = SelectNth(_root, index);
            return result == null ? default(K) : result.Key;
        }

        private static BinaryTreeNode<K, T> SelectNth(BinaryTreeNode<K, T> root, int index)
        {
            if (root == null)
                return null;

            var sizeLeft = Size(root.Left);
            if (index < sizeLeft)
            {
                return SelectNth(root.Left, index);
            }
            if (index > sizeLeft)
            {
                return SelectNth(root.Right, index - sizeLeft - 1);
            }

            return root;
        }
    }
}
