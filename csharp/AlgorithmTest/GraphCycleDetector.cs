using System.Collections.Generic;
using System.Linq;

namespace AlgorithmTest
{
    public static class GraphCycleDetector
    {
        public static IEnumerable<GraphNode<T>> DetectCycle<T>(Graph<T> g)
        {
            var currentPath = new Stack<GraphNode<T>>();
            foreach (var node in g.Nodes)
            {
                currentPath.Push(node);
                var result = Dfs(node, currentPath);
                
                if (result != null)
                    return result;

                currentPath.Pop();
            }

            return Enumerable.Empty<GraphNode<T>>();
        }

        private static IEnumerable<GraphNode<T>> Dfs<T>(GraphNode<T> node, Stack<GraphNode<T>> currentPath)
        {
            foreach (var graphNode in node.Adjuscens)
            {
                if (currentPath.Contains(graphNode))
                    return CollectCycle(currentPath, graphNode).ToList();

                currentPath.Push(graphNode);

                var dfsResult = Dfs(graphNode, currentPath);
                if (dfsResult != null)
                    return dfsResult;

                currentPath.Pop();
            }

            return null;
        }

        private static IEnumerable<GraphNode<T>> CollectCycle<T>(Stack<GraphNode<T>> currentPath, GraphNode<T> startNode)
        {
            while (currentPath.Peek() != startNode)
            {
                yield return currentPath.Pop();
            }

            yield return startNode;
        }
    }
}