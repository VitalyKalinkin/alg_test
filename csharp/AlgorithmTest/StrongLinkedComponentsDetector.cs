using System.Collections.Generic;
using System.Linq;

namespace AlgorithmTest
{
    public abstract class StrongLinkedComponentsDetector
    {
        public static IEnumerable<ISet<GraphNode<T>>> DetectStrongLinkedComponents<T>(Graph<T> g)
        {
            var reversedGraph = g.Reverse();
            var nodesInReversedPostorder = GetNodesInReversedPostOrder(reversedGraph);
            var marked = new HashSet<GraphNode<T>>();
            foreach (var graphNode in nodesInReversedPostorder
                                        .Select(x => g[x.Value])
                                        .Where(x => !marked.Contains(x)))
            {
                marked.Add(graphNode);
                var component = Bfs(graphNode, marked);
                yield return component;
            }
        }

        private static IEnumerable<GraphNode<T>> GetNodesInReversedPostOrder<T>(Graph<T> graph)
        {
            var stack = new Stack<GraphNode<T>>();
            var marked = new HashSet<GraphNode<T>>();
            foreach (var graphNode in graph.Nodes.Where(graphNode => !marked.Contains(graphNode)))
            {
                marked.Add(graphNode);
                Dfs(graphNode, stack, marked);
            }

            return stack;
        }

        private static void Dfs<T>(GraphNode<T> graphNode, Stack<GraphNode<T>> stack, ISet<GraphNode<T>> marked)
        {
            foreach (var source in graphNode.Adjuscens.Where(x => !marked.Contains(x)))
            {
                marked.Add(source);
                Dfs(source, stack, marked);
            }

            stack.Push(graphNode);
        }

        private static ISet<GraphNode<T>> Bfs<T>(GraphNode<T> node, ISet<GraphNode<T>> marked)
        {
            var q = new Queue<GraphNode<T>>();
            q.Enqueue(node);
            var result = new HashSet<GraphNode<T>> {node};

            while (q.Count > 0)
            {
                var curr = q.Dequeue();

                foreach (var graphNode in curr.Adjuscens.Where(x => !marked.Contains(x)))
                {
                    marked.Add(graphNode);
                    q.Enqueue(graphNode);
                    result.Add(graphNode);
                }
            }

            return result;
        }
    }
}