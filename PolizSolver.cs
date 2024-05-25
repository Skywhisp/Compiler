using System;
using System.Collections.Generic;

namespace Compiler
{
    internal class PolizSolver
    {
        public static double EvaluatePostfix(string postfix)
        {
            Stack<double> operandStack = new Stack<double>();
            foreach (string token in postfix.Split(' '))
            {
                if (double.TryParse(token, out double operand))
                {
                    operandStack.Push(operand);
                }
                else if (IsOperator(token))
                {
                    double operand2 = operandStack.Pop();
                    double operand1 = operandStack.Pop();
                    double result = ApplyOperator(token, operand1, operand2);
                    operandStack.Push(result);
                }
            }
            return operandStack.Pop();
        }
        static bool IsOperator(string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/" || token == "^";
        }
        static double ApplyOperator(string op, double operand1, double operand2)
        {
            switch (op)
            {
                case "+":
                    return operand1 + operand2;
                case "-":
                    return operand1 - operand2;
                case "*":
                    return operand1 * operand2;
                case "/":
                    if (operand2 == 0)
                    {
                        throw new DivideByZeroException("Division by zero.");
                    }
                    return operand1 / operand2;
                case "^":
                    return Math.Pow(operand1, operand2);
                default:
                    throw new ArgumentException("Invalid operator: " + op);
            }
        }
    }
}
