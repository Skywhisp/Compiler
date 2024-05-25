using Compiler;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Compiler
{
    internal class PolizConverter
    {
        static int GetPriority(char op)
        {
            switch (op)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                case '^':
                    return 3;
                default:
                    return 0;
            }
        }

        public static string InfixToPostfix(string infix)
        {
            string postfix = "";
            Stack<char> operatorStack = new Stack<char>();
            for (int i = 0; i < infix.Length; i++)
            {
                char c = infix[i];
                if (char.IsDigit(c))
                {
                    string number = c.ToString();
                    while (i + 1 < infix.Length && char.IsDigit(infix[i + 1]))
                    {
                        number += infix[i + 1];
                        i++;
                    }
                    postfix += number + " ";
                }
                else if (c == '(')
                {
                    if (i + 1 < infix.Length && infix[i + 1] == ')')
                    {
                        return "Встретились пустые скобки";
                    }
                    operatorStack.Push(c);
                }
                else if (c == ')')
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek() != '(')
                    {
                        postfix += operatorStack.Pop() + " ";
                    }
                    if (operatorStack.Count == 0)
                    {
                        return "Неверное расположение скобок";
                    }
                    operatorStack.Pop();
                }
                else if (IsOperator(c))
                {
                    while (operatorStack.Count > 0 && GetPriority(operatorStack.Peek()) >= GetPriority(c))
                    {
                        postfix += operatorStack.Pop() + " ";
                    }
                    operatorStack.Push(c);
                }
                else
                {
                    return $"Встретился недопустимый символ '{c}'";
                }
            }

            while (operatorStack.Count > 0)
            {
                postfix += operatorStack.Pop() + " ";
            }

            PolizItem polizItem = new PolizItem();
            polizItem.Result = PolizSolver.EvaluatePostfix(postfix.Trim());

            return postfix.Trim() + " = " + polizItem.Result.ToString();
        }

        static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/' || c == '^';
        }
    }
}
