using System;
using System.Collections.Generic;

namespace Challenge04
{
    public static class PostfixCalc
    {
        public static int Calculate(this string postfix)
        {
            var operandStack = new Stack<int>();

            foreach (var c in postfix)
            {
                if (char.IsNumber(c))
                    operandStack.Push(int.Parse($"{c}"));
                else
                {
                    var operandR = operandStack.Pop();
                    var operandL = operandStack.Pop();
                    int result;

                    switch (c)
                    {
                        case '+':
                            result = operandL + operandR;
                            break;

                        case '-':
                            result = operandL - operandR;
                            break;

                        case '*':
                            result = operandL*operandR;
                            break;

                        case '/':
                            result = operandL/operandR;
                            break;

                        default:
                            throw new InvalidOperationException($"Unknown operation: {c}");
                    }

                    operandStack.Push(result);
                }
            }

            if (operandStack.Count > 1)
                throw new InvalidOperationException("Too many operands");

            return operandStack.Pop();
        }
    }
}
