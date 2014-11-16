using System.Collections.Generic;

namespace AlgorithmTest
{
    public class Graph<T>
    {
        private readonly IDictionary<T, GraphNode<T>> _nodes = new Dictionary<T, GraphNode<T>>();

        public Graph<T> AddNode(GraphNode<T> node)
        {
            _nodes.Add(node.Value, node);
            return this;
        }

        public IEnumerable<GraphNode<T>> Nodes
        {
            get { return _nodes.Values; }
        }

        public GraphNode<T> this[T index]
        {
            get { return _nodes[index]; }
        } 
    }
}