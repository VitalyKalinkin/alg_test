using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmTest.Test
{
    public static class GraphConstractor
    {
        public static Graph<T> Construct<T>(IDictionary<T, IEnumerable<T>> structure) where T : IEquatable<T>
        {
            var result = new Graph<T>();
            foreach (var keyValue in structure)
            {
                result.AddNode(new GraphNode<T>(keyValue.Key));
            }

            foreach (var keyValue in structure)
            {
                var keyNode = result[keyValue.Key];
                foreach (var adjNode in keyValue.Value.Select(adj => result[adj]))
                {
                    keyNode.AddAdjuscent(adjNode);
                }
            }

            return result;
        }
    }
}
