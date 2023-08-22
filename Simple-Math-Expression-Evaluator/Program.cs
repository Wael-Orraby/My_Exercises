using Simple_Math_Expression_Evaluator;
using System;



    public static class Program
    {
        static void Main(string[] args)
        {
        var count = 0;
        while (true)
        {
            count++;
            Console.WriteLine("Please enter a math expression : ");
            var input = Console.ReadLine();
            var expr = ExpressionParser.Parse(input);
            Console.WriteLine($"Expression {count} : ");
            Console.WriteLine($"Left Side : {expr.LeftSideOperand}, Operation : {expr.Operation}, Right Side : {expr.RightSideOperand}");
            Console.WriteLine($"{input} = {EvaluateExpression(expr)}");
            Console.WriteLine();
            Console.WriteLine("###############################################################");
            Console.WriteLine();
        }
        }
    private static object EvaluateExpression(MathExpression expr)
    {
        switch (expr.Operation)
        {
            case MathOperation.Addition:
                return expr.LeftSideOperand + expr.RightSideOperand;
            case MathOperation.Substraction:
                return expr.LeftSideOperand - expr.RightSideOperand;
            case MathOperation.Multiplication:
                return expr.LeftSideOperand * expr.RightSideOperand;
            case MathOperation.Division:
                return expr.LeftSideOperand / expr.RightSideOperand;
            case MathOperation.Modulus:
                return expr.LeftSideOperand % expr.RightSideOperand;
            case MathOperation.Power:
                return Math.Pow(expr.LeftSideOperand, expr.RightSideOperand);
            case MathOperation.Sin:
                return Math.Sin(expr.RightSideOperand);
            case MathOperation.Cos:
                return Math.Cos(expr.RightSideOperand);
            case MathOperation.Tan:
                return Math.Tan(expr.RightSideOperand);
            default:
                return 0;
        }
    }

}
