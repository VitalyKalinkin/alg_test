using System.Collections;
using System.Collections.Generic;

namespace AlgorithmTest
{
    public static class BreadthFirstSearch<T>
    {
        public static IEnumerable<IEnumerable<GeneralTreeNode<T>>> SplitByLevels(GeneralTreeNode<T> root)
        {
            var bfsQueue = new Queue<GeneralTreeNode<T>>();
            var currentLevel = new List<GeneralTreeNode<T>>();

            bfsQueue.Enqueue(root);
            bfsQueue.Enqueue(GeneralTreeNode<T>.Empty);

            while (bfsQueue.Count > 0)
            {
                var item = bfsQueue.Dequeue();

                if (item == GeneralTreeNode<T>.Empty)
                {
                    yield return currentLevel;
                    currentLevel = new List<GeneralTreeNode<T>>();
                    
                    if (bfsQueue.Count > 0)
                        bfsQueue.Enqueue(GeneralTreeNode<T>.Empty);

                    continue;
                }

                currentLevel.Add(item);

                foreach (var childNode in item.ChildNodes)
                {
                    bfsQueue.Enqueue(childNode);
                }
            }
        }
    }
}
