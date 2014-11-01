using System;
using System.Collections.Generic;

namespace AlgorithmTest
{
    public class MaximumBinaryHeap<T> where T: IComparable<T>
    {
        private T[] _array = new T[4];
        private int _n;

        public void Add(T item)
        {
            if (_array.Length == _n + 1)
            {
                Resize(2*_n);
            }

            _array[++_n] = item;
            Swim(_n);
        }

        private void Swim(int nodeIndex)
        {
            while (nodeIndex > 1)
            {
                if (_array[nodeIndex/2].CompareTo(_array[nodeIndex]) < 0)
                {
                    _array.Swap(nodeIndex/2, nodeIndex);
                }
                else
                {
                    break;
                }

                nodeIndex /= 2;
            }
        }

        private void Resize(int newSize)
        {
            var newArray = new T[newSize];

            for (var i = 0; i < Math.Min(newSize, _array.Length); ++i)
            {
                newArray[i] = _array[i];
            }

            _array = newArray;
        }

        public T GetMaxumum()
        {
            if (_n == 0)
                throw new InvalidOperationException("Heap is empty!");

            var result = _array[1];
            _array.Swap(1, _n--);
            Sink(1);
            _array[_n + 1] = default(T);

            if (_array.Length > _n * 4)
            {
                Resize(_array.Length / 2);
            }

            return result;
        }

        private void Sink(int nodeIndex)
        {
            while (nodeIndex * 2 <= _n)
            {
                int childNode = nodeIndex*2;
                if (childNode < _n && _array[childNode].CompareTo(_array[childNode + 1]) < 0) 
                    childNode++;

                if (_array[nodeIndex].CompareTo(_array[childNode]) >= 0)
                {
                    break;
                }

                _array.Swap(childNode, nodeIndex);
                nodeIndex = childNode;
            }
        }
    }
}
