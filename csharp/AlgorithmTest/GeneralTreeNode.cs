using System.Collections.Generic;
using System.Linq;

namespace AlgorithmTest
{
    public class GeneralTreeNode<T>
    {
        public static GeneralTreeNode<T> Empty = new GeneralTreeNode<T>(default(T)); 

        public T Payload { get; private set; }

        public IEnumerable<GeneralTreeNode<T>> ChildNodes { get; private set; } 

        public GeneralTreeNode(T payload, IEnumerable<GeneralTreeNode<T>> childNodes)
        {
            Payload = payload;
            ChildNodes = childNodes;
        }

        public GeneralTreeNode(T payload) : this(payload, Enumerable.Empty<GeneralTreeNode<T>>())
        {
        }
    }
}
