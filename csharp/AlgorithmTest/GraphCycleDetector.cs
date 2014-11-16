using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace AlgorithmTest
{
    public static class GraphCycleDetector
    {
        class ListEqualityComparer<T> : IEqualityComparer<IEnumerable<GraphNode<T>>>
        {
            public bool Equals(IEnumerable<GraphNode<T>> x, IEnumerable<GraphNode<T>> y)
            {
                return !x.Except(y).Any();
            }

            public int GetHashCode(IEnumerable<GraphNode<T>> obj)
            {
                return obj.Aggregate(17, (x, node) => 31*x + node.GetHashCode());
            }
        }

        public static IEnumerable<IEnumerable<GraphNode<T>>> DetectAllCycles<T>(Graph<T> g) where T : IComparable<T>
        {
            ISet<IEnumerable<GraphNode<T>>> returned = new HashSet<IEnumerable<GraphNode<T>>>(new ListEqualityComparer<T>());
            var currentPath = new Stack<GraphNode<T>>();
            foreach (var node in g.Nodes)
            {
                currentPath.Push(node);
                var result = Dfs(node, currentPath);

                foreach (var partOfResult in result.Select(CycleShiftToMinimum).Where(x => !returned.Contains(x)))
                {
                    returned.Add(partOfResult);
                    yield return partOfResult;
                }

                currentPath.Pop();
            }
        }

        private static IList<GraphNode<T>> CycleShiftToMinimum<T>(IEnumerable<GraphNode<T>> seq) where T : IComparable<T>
        {
            var list = seq.ToList();
            var minValue = list.Min(x => x.Value);
            var minNode = list.First(x => x.Value.Equals(minValue));
            var minIndex = list.IndexOf(minNode);

            return list.Skip(minIndex).Concat(list.Take(minIndex)).ToList();
        }

        private static IEnumerable<IEnumerable<GraphNode<T>>> Dfs<T>(GraphNode<T> node, Stack<GraphNode<T>> currentPath)
        {
            foreach (var graphNode in node.Adjuscens)
            {
                if (currentPath.Contains(graphNode))
                {
                    yield return CollectCycle(currentPath, graphNode);
                    yield break;
                }

                currentPath.Push(graphNode);

                var dfsResult = Dfs(graphNode, currentPath);
                foreach (var partOfResult in dfsResult.Where(x => x != null))
                    yield return partOfResult;

                currentPath.Pop();
            }
        }

        private static IList<GraphNode<T>> CollectCycle<T>(IEnumerable<GraphNode<T>> currentPath, GraphNode<T> startNode)
        {
            var result = new List<GraphNode<T>>();
            foreach (var node in currentPath)
            {
                if (node == startNode)
                {
                    result.Add(startNode);
                    result.Reverse();
                    return result;
                }

                result.Add(node);
            }

            return null;
        }
    }
}