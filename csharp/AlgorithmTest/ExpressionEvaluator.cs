using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmTest
{
    public class ExpressionEvaluator
    {
        public int Evaluate(string expression)
        {
            var tokenizedExpr = Tokenize(expression);

            var postfixExpr = ConvertToPostfixExpression(tokenizedExpr);

            var stack = new Stack<int>();
            foreach (var token in postfixExpr)
            {
                if (token.IsNumber)
                {
                    stack.Push(token.Number);
                }
                else
                {
                    var op2 = stack.Pop();
                    var op1 = stack.Pop();
                    stack.Push(DoOperation(token.Operation, op1, op2));
                }
            }

            return stack.Pop();
        }

        private int DoOperation(Operation operation, int a1, int a2)
        {
            switch (operation)
            {
                case Operation.Add: return a1 + a2;
                case Operation.Mult: return a1 * a2;
                case Operation.Sub: return a1 - a2;
                case Operation.Div: return a1 / a2;
            }

            return 0;
        }

        public IList<Token> ConvertToPostfixExpression(IEnumerable<Token> tokens)
        {
            var opStack = new Stack<Token>();
            var result = new List<Token>();

            foreach (var token in tokens)
            {
                if (token.IsNumber)
                {
                    result.Add(token);
                }
                else
                {
                    if (token.Operation == Operation.ClosingPar)
                    {
                        while (opStack.Any() && opStack.Peek().Operation != Operation.OpeningPar)
                        {
                            result.Add(opStack.Pop());
                        }

                        if (opStack.Any())
                            opStack.Pop();
                    }
                    else
                    {
                        while (opStack.Any() && InputPriorityMap[token.Operation] <= StackPriorityMap[opStack.Peek().Operation])
                        {
                            var operation = opStack.Pop();
                            if (operation.Operation != Operation.ClosingPar &&
                                operation.Operation != Operation.OpeningPar)
                            {
                                result.Add(operation);
                            }
                        }

                        opStack.Push(token);
                    }
                }
            }

            while (opStack.Any())
            {
                var operation = opStack.Pop();
                if (operation.Operation != Operation.ClosingPar && operation.Operation != Operation.OpeningPar)
                {
                    result.Add(operation);
                }
            }

            return result;
        }

        public IList<Token> Tokenize(string expression)
        {
            var result = new List<Token>();

            int index = 0;
            while (index < expression.Length)
            {
                if (char.IsDigit(expression[index]))
                {
                    int number = 0;
                    while (index < expression.Length && char.IsDigit(expression[index]))
                    {
                        number = number*10 + Int32.Parse(expression[index].ToString());
                        index++;
                    }
                    result.Add(new Token {Number = number});
                }
                else
                {
                    result.Add(new Token{Operation = ParseOperation(expression[index])});
                    index++;
                }
            }

            return result;
        }

        private static readonly IDictionary<char, Operation> OperationMap = new Dictionary<char, Operation>()
        {
            {'(', Operation.OpeningPar},
            {')', Operation.ClosingPar},
            {'+', Operation.Add},
            {'/', Operation.Div},
            {'-', Operation.Sub},
            {'*', Operation.Mult}
        };

        private static readonly IDictionary<Operation, int> StackPriorityMap = new Dictionary<Operation, int>()
        {
            {Operation.Add, 1},
            {Operation.Sub, 1},
            {Operation.Mult, 2},
            {Operation.Div, 2},
            {Operation.OpeningPar, 0},
            {Operation.ClosingPar, 3},
        };

        private static readonly IDictionary<Operation, int> InputPriorityMap = new Dictionary<Operation, int>()
        {
            {Operation.Add, 1},
            {Operation.Sub, 1},
            {Operation.Mult, 2},
            {Operation.Div, 2},
            {Operation.OpeningPar, 3},
            {Operation.ClosingPar, 3},
        };

        private Operation ParseOperation(char ch)
        {
            return OperationMap[ch];
        }
    }

    public class Token
    {
        private Operation? _operation;
        private int? _number;

        public bool IsNumber
        {
            get { return _number.HasValue; }
        }

        public int Number
        {
            get { return _number.Value; }
            set { _number = value; }
        }

        public bool IsOperation
        {
            get { return _operation != null; }
        }

        public Operation Operation
        {
            get { return _operation.Value; }
            set { _operation = value; }
        }

        protected bool Equals(Token other)
        {
            return _operation == other._operation && _number == other._number;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Token) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_operation.GetHashCode()*397) ^ _number.GetHashCode();
            }
        }

        public override string ToString()
        {
            return string.Format("Operation: {0}, Number: {1}", _operation.HasValue ? _operation.ToString() : "N/A", _number.HasValue ? _number.ToString() : "N/A");
        }
    }

    public enum Operation
    {
        Add,
        Mult,
        Sub,
        Div,
        OpeningPar,
        ClosingPar  
    }
}