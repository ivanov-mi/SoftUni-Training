using System;
using System.Collections.Generic;

class BalancedParentheses
{
    static void Main()
    {
        string expression = Console.ReadLine();
        Stack<char> parenthesisStack = new Stack<char>();

        if (expression.Length % 2 != 0)
        {
            Console.WriteLine("NO");
            return;
        }

        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '{' || expression[i] == '[' || expression[i] == '(')
            {
                parenthesisStack.Push(expression[i]);
            }
            else if (expression[i] == '}' && parenthesisStack.Peek() == '{' && parenthesisStack.Count > 0)
            {
                parenthesisStack.Pop();
            }
            else if (expression[i] == ']' && parenthesisStack.Peek() == '[' && parenthesisStack.Count > 0)
            {
                parenthesisStack.Pop();
            }
            else if (expression[i] == ')' && parenthesisStack.Peek() == '(' && parenthesisStack.Count > 0)
            {
                parenthesisStack.Pop();
            }
            else
            {
                break;  
            }
        }
        

        if (parenthesisStack.Count > 0)
        {
            Console.WriteLine("NO");
        }
        else
        {
            Console.WriteLine("YES");
        }
    }
}

