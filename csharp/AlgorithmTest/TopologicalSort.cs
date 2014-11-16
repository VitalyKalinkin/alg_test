using System.Collections.Generic;
using System.Linq;

namespace AlgorithmTest
{
    public static class TopologicalSort
    {
        public static IEnumerable<GraphNode<T>> TopologicallySort<T>(Graph<T> g)
        {
            var marked = new HashSet<GraphNode<T>>();
            var stack = new Stack<GraphNode<T>>();
            foreach (var node in g.Nodes.Where(node => !marked.Contains(node)))
            {
                marked.Add(node);
                Dfs(node, marked, stack);
            }

            return stack;
        }

        private static void Dfs<T>(GraphNode<T> node, ISet<GraphNode<T>> marked, Stack<GraphNode<T>> stack)
        {
            foreach (var graphNode in node.Adjuscens.Where(graphNode => !marked.Contains(graphNode)))
            {
                marked.Add(graphNode);
                Dfs(graphNode, marked, stack);
            }

            stack.Push(node);
        }
    }
}