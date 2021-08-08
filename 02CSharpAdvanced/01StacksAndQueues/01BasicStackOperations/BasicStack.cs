using System;
using System.Collections.Generic;
using System.Linq;

class BasicStack
{
    static void Main()
    {
        int[] elements = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int elementsToPush = elements[0];
        int elementsToPop = elements[1];
        int searchedNumber = elements[2];

        Stack<int> basicStack = new Stack<int>(elementsToPush);

        int[] numbers = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        for (int i = 0; i < Math.Min(elementsToPush, numbers.Length); i++)
        {
            basicStack.Push(numbers[i]);
        }

        for (int i = 0; i < elementsToPop; i++)
        {
            if (basicStack.Count > 0)
            {
                basicStack.Pop();
            }
        }

        if (basicStack.Count == 0)
        {
            Console.WriteLine(0);
        }
        else if (basicStack.Contains(searchedNumber))
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine(basicStack.Min());
        }
    }
}

