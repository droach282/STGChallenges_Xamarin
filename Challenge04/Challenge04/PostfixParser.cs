using System.Collections.Generic;
using System.Text;

namespace Challenge04
{
    public static class PostfixParser
    {
        public static string ToPostfix(this string infix)
        {
            var operatorStack = new Stack<char>();
            var outputQueue = new Queue<char>();
            var operators = new Dictionary<char, short>
            {
                {'*', 3},
                {'/', 3},
                {'+', 2},
                {'-', 2},
                {'(', 1} // don't want to pop this prematurely.
            };

            for (var i = 0; i < infix.Length; i++)
            {
                var current = infix[i];

                if (char.IsNumber(current))
                {
                    outputQueue.Enqueue(current);
                    continue;
                }

                if (operators.ContainsKey(current) && operators[current] != 1) // skip '(', handled below.
                {
                    while (operatorStack.Count > 0 && operators[current] <= operators[operatorStack.Peek()])
                        outputQueue.Enqueue(operatorStack.Pop());

                    operatorStack.Push(current);
                    continue;
                }

                if (current == '(')
                {
                    // handle inferred '*' operation
                    if (i > 0 && (char.IsNumber(infix[i-1]) || infix[i-1] == ')'))
                        operatorStack.Push('*');

                    operatorStack.Push(current);
                    continue;
                }

                if (current == ')')
                {
                    while (operatorStack.Peek() != '(')
                        outputQueue.Enqueue(operatorStack.Pop());

                    operatorStack.Pop(); // throw out '('
                }
            }

            while (operatorStack.Count > 0)
                outputQueue.Enqueue(operatorStack.Pop());

            var sb = new StringBuilder();
            while (outputQueue.Count > 0)
                sb.Append(outputQueue.Dequeue());

            return sb.ToString();
        }
    }
}
