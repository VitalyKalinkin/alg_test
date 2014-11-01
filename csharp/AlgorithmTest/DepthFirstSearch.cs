using System.Collections.Generic;
using System.Linq;

namespace AlgorithmTest
{
    public static class DepthFirstSearch
    {
        public static IEnumerable<GeneralTreeNode<T>> GetPathToNode<T>(GeneralTreeNode<T> root, T valueToFind)
        {
            var dfsStack = new Stack<GeneralTreeNode<T>>();
            dfsStack.Push(root);

            var resultStack = new Stack<GeneralTreeNode<T>>();
            while (dfsStack.Count > 0)
            {
                var item = dfsStack.Pop();

                // If we meet a special node this means we finished with the branch
                // for the top item on resultStack. We need to remove it as we did not find the needed value.
                if (item == GeneralTreeNode<T>.Empty)
                {
                    resultStack.Pop();
                    continue;
                }
                    
                // Adds current item as a possible part of path to the needed node.
                resultStack.Push(item);

                // If we found the result, return it.
                if (item.Payload.Equals(valueToFind))
                {
                    return resultStack.Reverse().ToList();
                }

                // Going deeper each level we insert a special node.
                // Then after me met it later we pop a node from the result stack as we finished with all childs.
                dfsStack.Push(GeneralTreeNode<T>.Empty);
                foreach (var node in item.ChildNodes)
                {
                    dfsStack.Push(node);
                }
            }

            return Enumerable.Empty<GeneralTreeNode<T>>();
        } 
    }
}
