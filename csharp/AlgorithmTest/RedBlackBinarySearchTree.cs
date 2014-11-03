using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmTest
{
    public class RedBlackBinarySearchTree<K, T> : BinarySearchTree<K, T> where K : IComparable<K>
    {
        public override void Add(K key, T value)
        {
            _root = AddRBRecursive(_root, key, value);
        }

        private static BinaryTreeNode<K, T> AddRBRecursive(BinaryTreeNode<K, T> root, K key, T value)
        {
            if (root == null)
                return new BinaryTreeNode<K, T>(key, value) {Color = RbColor.Red};

            var cmp = key.CompareTo(root.Key);

            if (cmp < 0)
            {
                root.Left = AddRBRecursive(root.Left, key, value);
            }
            else if (cmp > 0)
            {
                root.Right = AddRBRecursive(root.Right, key, value);
            }
            else
            {
                root = new BinaryTreeNode<K, T>(key, value) {Left = root.Left, Right = root.Right, Color = root.Color};
            }

            if (IsRed(root.Right) && !IsRed(root.Left))
                root = RotateLeft(root);
            if (IsRed(root.Left) && IsRed(root.Left.Left))
                root = RotateRight(root);
            if (IsRed(root.Left) && IsRed(root.Right))
                FlipColors(root);

            root.Size = 1 + Size(root.Left) + Size(root.Right);
            return root;
        }

        private static void FlipColors(BinaryTreeNode<K, T> root)
        {
            root.Left.Color = RbColor.Black;
            root.Right.Color = RbColor.Black;
            root.Color = RbColor.Red;
        }

        private static BinaryTreeNode<K, T> RotateRight(BinaryTreeNode<K, T> root)
        {
            var x = root.Right;
            root.Left = x.Right;
            x.Right = root;
            x.Color = root.Color;
            root.Color = RbColor.Red;

            root.Size = 1 + Size(root.Left) + Size(root.Right);

            return x;
        }

        private static BinaryTreeNode<K, T> RotateLeft(BinaryTreeNode<K, T> root)
        {
            var x = root.Right;
            root.Right = x.Left;
            x.Left = root;
            x.Color = root.Color;
            root.Color = RbColor.Red;

            root.Size = 1 + Size(root.Left) + Size(root.Right);

            return x;
        }

        private static bool IsRed(BinaryTreeNode<K, T> root)
        {
            if (root == null)
                return false;
            return root.Color == RbColor.Red;
        }
    }
}
