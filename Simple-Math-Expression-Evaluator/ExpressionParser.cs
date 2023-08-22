using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Math_Expression_Evaluator
{
    internal static class ExpressionParser
    {
        private const string MathSymbols = "+*/%^";
        public static MathExpression Parse(string input)
        {
            input = input.Trim();
            var expr = new MathExpression();
            var token = "";
            bool leftSideIntialized = false;
            for (int i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];
                if (char.IsDigit(currentChar))
                {
                    token += currentChar;
                    if (i == input.Length - 1 && leftSideIntialized)
                    {
                        expr.RightSideOperand = double.Parse(token);
                        break;
                    }
                }
                else if (MathSymbols.Contains(currentChar))
                {
                    if (!leftSideIntialized)
                    {
                    expr.LeftSideOperand = double.Parse(token);
                    leftSideIntialized = true;
                    }
                    expr.Operation = ParseMathOperation(currentChar.ToString());
                    token = "";
                }
                else if (currentChar == '-' && i > 0)
                {
                    if (expr.Operation == MathOperation.None)
                    {
                        expr.Operation = MathOperation.Substraction;
                        expr.LeftSideOperand = double.Parse(token);
                        leftSideIntialized = true;
                        token = "";
                    }
                    else
                        token += currentChar;
                }
                else if (char.IsLetter(currentChar))
                {
                    token += currentChar;
                    leftSideIntialized = true;
                }
                else if (currentChar == ' ')
                {
                    if (!leftSideIntialized)
                    {
                        expr.LeftSideOperand = double.Parse(token);
                        token = "";
                        leftSideIntialized = true;
                    }
                    else if (expr.Operation == MathOperation.None)
                    {
                        expr.Operation = ParseMathOperation(token);
                        token = "";
                    }
                }
                else
                    token += currentChar;
            }
            return expr;
        }

        private static MathOperation ParseMathOperation(string token)
        {
            switch (token)
            {
                case "+":
                    return MathOperation.Addition;
                case "*":
                    return MathOperation.Multiplication;
                case "/":
                    return MathOperation.Division;
                case "%":
                case "mod":
                    return MathOperation.Modulus;
                case "^":
                case "pow":
                    return MathOperation.Power;
                case "sin":
                    return MathOperation.Sin;
                case "cos":
                    return MathOperation.Cos;
                case "tan":
                    return MathOperation.Tan;
                default:
                    return MathOperation.None;
            }
        }
    }
}
