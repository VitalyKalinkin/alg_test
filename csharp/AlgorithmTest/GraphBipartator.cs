using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlgorithmTest
{
    public static class GraphBipartator
    {
        public static Tuple<IEnumerable<GraphNode<T>>, IEnumerable<GraphNode<T>>> Bipartite<T>(Graph<T> graph)
        {
            var colors = new Dictionary<GraphNode<T>, bool>(); 
            foreach (var graphNode in graph.Nodes.Where(graphNode => !colors.ContainsKey(graphNode)))
            {
                colors[graphNode] = true;
                Bfs(graphNode, colors);
            }

            return new Tuple<IEnumerable<GraphNode<T>>, IEnumerable<GraphNode<T>>>(
                colors.Where(x => x.Value).Select(x => x.Key),
                colors.Where(x => !x.Value).Select(x => x.Key));
        }

        private static void Bfs<T>(GraphNode<T> graphNode, Dictionary<GraphNode<T>, bool> colors)
        {
            var q = new Queue<GraphNode<T>>();
            q.Enqueue(graphNode);

            while (q.Count > 0)
            {
                var curr = q.Dequeue();
                var currColor = colors[curr];

                foreach (var node in curr.Adjuscens)
                {
                    if (!colors.ContainsKey(node))
                    {
                        q.Enqueue(node);
                        colors[node] = !currColor;
                    }
                    else if (colors[node] == currColor)
                    {
                        throw new InvalidDataException("Can't bipartite this graph!");
                    }
                }
            }
        }
    }
}