using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Constraints;

namespace AlgorithmTest.Test
{
    class MoreThan
    {
        public static IResolveConstraint Sorted<T>(Func<T, T, int> comparer)
        {
            return new SortedConstraintResolver<T>(comparer);
        }

        public static IResolveConstraint Sorted<T>() where T : IComparable<T>
        {
            return new SortedConstraintResolver<T>((x, y) => x.CompareTo(y));
        }

        public static IResolveConstraint InTopologicalOrder<T>(Graph<T> g)
        {
            return new TopologicalConstraintResolver<T>(g);
        }
    }

    internal class TopologicalConstraintResolver<T> : IResolveConstraint
    {
        private Graph<T> g; 

        public TopologicalConstraintResolver(Graph<T> graph)
        {
            g = graph;
        }
        public Constraint Resolve()
        {
            return new TopologicalConstraint<T>(g);
        }
    }

    internal class TopologicalConstraint<T> : Constraint
    {
        private Graph<T> g;
        private IEnumerable<GraphNode<T>> _enumerable;
        private List<GraphNode<T>> _passed;

        public TopologicalConstraint(Graph<T> graph)
        {
            g = graph;
        }

        public override bool Matches(object actual)
        {
            _enumerable = actual as IEnumerable<GraphNode<T>>;

            if (_enumerable == null)
                throw new ArgumentException(String.Format("Argument must be not null and has type {0}", typeof(IEnumerable<T>).ToString()), "actual");

            _passed = new List<GraphNode<T>>();

            foreach (var graphNode in _enumerable)
            {
                if (_passed.Intersect(graphNode.Adjuscens).Any())
                {
                    return false;
                }

                _passed.Add(graphNode);
            }

            return true;
        }

        public override void WriteDescriptionTo(MessageWriter writer)
        {
            writer.WriteMessageLine("An enumerable sorting failed at index {0}", _passed.Count);
            writer.WriteActualValue(_enumerable);
        }
    }

    internal class SortedConstraintResolver<T> : IResolveConstraint
    {
        private readonly Func<T, T, int> _comparer;

        public SortedConstraintResolver(Func<T, T, int> comparer)
        {
            _comparer = comparer;
        }

        public Constraint Resolve()
        {
            return new SortedConstraint<T>(_comparer);
        }
    }

    internal class SortedConstraint<T> : Constraint
    {
        private readonly Func<T, T, int> _comparer;
        private int _index;
        private IEnumerable<T> _enumerable;

        public SortedConstraint(Func<T, T, int> comparer)
        {
            _comparer = comparer;
        }

        public override bool Matches(object actual)
        {
            _enumerable = actual as IEnumerable<T>;

            if (_enumerable == null)
                throw new ArgumentException(String.Format("Argument must be not null and has type {0}", typeof(IEnumerable<T>).ToString()), "actual");

            T previous = default(T);
            _index = 0;

            foreach (var enumerableItem in _enumerable)
            {
                if (_index > 0 && _comparer(previous, enumerableItem) > 0)
                {
                    return false;
                }

                _index++;
                previous = enumerableItem;
            }

            return true;
        }

        public override void WriteDescriptionTo(MessageWriter writer)
        {
            var startIndex = Math.Max(_index - 1, 0);
            writer.WriteMessageLine("An enumerable sorting failed at index {0}", _index);
            writer.WriteActualValue(_enumerable);
        }
    }
}
