using System;

namespace AlgorithmTest
{
    public class BinaryTreeNode<K, T> where K : IComparable<K>
    {
        public BinaryTreeNode(K key, T payload)
        {
            Key = key;
            Payload = payload;
        }

        public K Key { get; private set; }
        public T Payload { get; private set; }

        public BinaryTreeNode<K, T> Left { get; set; }
        public BinaryTreeNode<K, T> Right { get; set; }
        public int Size { get; set; }
    }
}
