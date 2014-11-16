using System.Collections.Generic;

namespace AlgorithmTest
{
    public class GraphNode<T>
    {
        private readonly T _value;
        private readonly ISet<GraphNode<T>> _adjuscens = new HashSet<GraphNode<T>>();

        public GraphNode(T value)
        {
            _value = value;
        }

        public GraphNode<T> AddAdjuscent(GraphNode<T> node)
        {
            _adjuscens.Add(node);
            return this;
        }

        public T Value
        {
            get { return _value; }
        }

        public ISet<GraphNode<T>> Adjuscens
        {
            get { return _adjuscens; }
        }

        public override string ToString()
        {
            return string.Format("{0}", _value);
        }
    }
}
