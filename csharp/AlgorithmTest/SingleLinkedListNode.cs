
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmTest
{
    public class SingleLinkedListNode<T>
    {
        public SingleLinkedListNode(SingleLinkedListNode<T> nextNode, T payload)
        {
            NextNode = nextNode;
            Payload = payload;
        }

        public SingleLinkedListNode<T> NextNode { get; set; }
        public T Payload { get; private set; }

        public static Builder NewBuilder()
        {
            return new Builder();
        }

        public override string ToString()
        {
            return string.Format("Payload: {0}", Payload);
        }

        public class Builder
        {
            private readonly List<T> _nodes = new List<T>();

            public Builder AddNode(T nodeValue)
            {
                _nodes.Add(nodeValue);
                return this;
            }

            public Builder AddNodes(IEnumerable<T> nodeValues)
            {
                _nodes.AddRange(nodeValues);
                return this;
            }

            public SingleLinkedListNode<T> Build()
            {
                _nodes.Reverse();

                return _nodes.Aggregate<T, SingleLinkedListNode<T>>(null, (current, nodeValue) => new SingleLinkedListNode<T>(current, nodeValue));
            }
        }
    }
}
