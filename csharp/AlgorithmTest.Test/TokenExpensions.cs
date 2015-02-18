using System.Collections.Generic;
using System.Text;

namespace AlgorithmTest.Test
{
    public static class TokenExpensions
    {
        public static string Stringify(this IList<Token> list)
        {
            var result = new StringBuilder();

            foreach (var token in list)
            {
                result.Append(token.IsNumber
                    ? string.Format("{0} ", token.Number)
                    : string.Format("{0} ", token.Operation.Stringify()));
            }

            return result.ToString().Trim();
        }

        public static string Stringify(this Operation op)
        {
            switch (op)
            {
                    case Operation.Add: return "+";
                    case Operation.Mult: return "*";
                    case Operation.OpeningPar: return "(";
                    case Operation.Sub: return "-";
                    case Operation.ClosingPar: return ")";
                    case Operation.Div: return "/";
            }

            return "NULL";
        }
    }
}