using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;

namespace AlgorithmTest.Test
{
    class MoreIs
    {
        public static IResolveConstraint Sorted<T>(Func<T, T, int> comparer)
        {
            return new SortedConstraintResolver<T>(comparer);
        }

        public static IResolveConstraint Sorted<T>() where T : IComparable<T>
        {
            return new SortedConstraintResolver<T>((x, y) => x.CompareTo(y));
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
                if (_index > 0 && _comparer(previous, enumerableItem) >= 0)
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
