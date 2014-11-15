using System.Collections.Generic;

namespace AlgorithmTest
{
    public class Graph<T>
    {
        private readonly ISet<GraphNode<T>> _nodes = new HashSet<GraphNode<T>>();

        public Graph<T> AddNode(GraphNode<T> node)
        {
            _nodes.Add(node);
            return this;
        }

        public ISet<GraphNode<T>> Nodes
        {
            get { return _nodes; }
        }
    }
}