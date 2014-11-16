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

        protected bool Equals(GraphNode<T> other)
        {
            return EqualityComparer<T>.Default.Equals(_value, other._value) && Equals(_adjuscens, other._adjuscens);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((GraphNode<T>) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<T>.Default.GetHashCode(_value)*397) ^ (_adjuscens != null ? _adjuscens.GetHashCode() : 0);
            }
        }

        public override string ToString()
        {
            return string.Format("{0}", _value);
        }
    }
}
