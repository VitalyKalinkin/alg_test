using System;
using System.Collections;
using NUnit.Framework;

namespace AlgorithmTest.Test
{
    [TestFixture]
    public class ExpressionEvaluatorTest
    {
        [Test]
        [TestCase("2", 2)]
        [TestCase("2+2", 4)]
        [TestCase("2+2*2", 6)]
        [TestCase("2+2-2", 2)]
        [TestCase("2+2*2/1+2", 8)]
        [TestCase("(2)", 2)]
        [TestCase("(2+2)", 4)]
        [TestCase("(2+2)*2", 8)]
        [TestCase("((2+2)*2+2)*2", 20)]
        [TestCase("((2+2)*2+2)*(5+6*(17-3))", 890)]
        [TestCase("(4+8)*(6-5)/((3-2)*(2+2))", 3)]
        [TestCase("(300+23)*(43-21)/(12+7)", 374)]
        [TestCase("3+4*5/10", 5)]
        public void SimpleExpression(string expr, int expectedResult)
        {
            var evaluator = new ExpressionEvaluator();
            Assert.That(evaluator.Evaluate(expr), Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("2", "2")]
        [TestCase("2+2", "2 2 +")]
        [TestCase("2+2*2", "2 2 2 * +")]
        [TestCase("2+2-2", "2 2 + 2 -")]
        [TestCase("2+2*2/1+2", "2 2 2 * 1 / + 2 +")]
        [TestCase("(2)", "2")]
        [TestCase("(2+2)", "2 2 +")]
        [TestCase("(2+2)*2", "2 2 + 2 *")]
        [TestCase("3+4*5/10", "3 4 5 * 10 / +")]
        [TestCase("((2+2)*2+2)*2", "2 2 + 2 * 2 + 2 *")]
        [TestCase("((2+2)*2+2)*(5+6*(17-3))", "2 2 + 2 * 2 + 5 6 17 3 - * + *")]
        [TestCase("(300+23)*(43-21)/(12+7)", "300 23 + 43 21 - * 12 7 + /")]
        [TestCase("(4+8)*(6-5)/((3-2)*(2+2))", "4 8 + 6 5 - * 3 2 - 2 2 + * /")]
        public void SimplePostfixNotation(String expr, String expected)
        {
            var evaluator = new ExpressionEvaluator();
            Assert.That(evaluator.ConvertToPostfixExpression(evaluator.Tokenize(expr)).Stringify(), Is.EqualTo(expected));
        }

        [Test]
        [TestCaseSource("TestCasesForTokenizer")]
        public string SimpleTokenization(string expr)
        {
            var evaluator = new ExpressionEvaluator();
            return evaluator.Tokenize(expr).Stringify();
        }

        public IEnumerable TestCasesForTokenizer
        {
            get
            {
                yield return new TestCaseData("2").Returns("2"); 
                yield return new TestCaseData("223").Returns("223"); 
                yield return new TestCaseData("(2)").Returns("( 2 )");
                yield return new TestCaseData("(4+8)*(6-5)/((3-2)*(2+2))").Returns("( 4 + 8 ) * ( 6 - 5 ) / ( ( 3 - 2 ) * ( 2 + 2 ) )");
                yield return new TestCaseData("223*456+(111/345)").Returns("223 * 456 + ( 111 / 345 )"); 
            }
        }
    }
}