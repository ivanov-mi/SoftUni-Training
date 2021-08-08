using System;
using System.Collections.Generic;
using System.Linq;

class MaximumAndMinimumElement
{
    static void Main()
    {
        int numberOFQueries = int.Parse(Console.ReadLine());
        Stack<int> stackOfInts = new Stack<int>();

        Stack<int> minValue = new Stack<int>();
        minValue.Push(int.MaxValue);

        Stack<int> maxValue = new Stack<int>();
        maxValue.Push(int.MinValue);

        for (int i = 0; i < numberOFQueries; i++)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int command = input[0];

            switch (command)
            {
                case 1:
                    int elementToPush = input[1];
                    stackOfInts.Push(elementToPush);

                    if (elementToPush < minValue.Peek())
                    {
                        minValue.Push(elementToPush);
                    }
                    else
                    {
                        minValue.Push(minValue.Peek());
                    }

                    if (elementToPush > maxValue.Peek())
                    {
                        maxValue.Push(elementToPush);
                    }
                    else
                    {
                        maxValue.Push(maxValue.Peek());
                    }

                    break;

                case 2:
                    if (stackOfInts.Count > 0)
                    {
                        stackOfInts.Pop();
                        minValue.Pop();
                        maxValue.Pop();
                    }
                    break;

                case 3:
                    if (stackOfInts.Count > 0)
                    {
                        Console.WriteLine(maxValue.Peek());
                    }
                    break;

                case 4:
                    if (stackOfInts.Count > 0)
                    {
                        Console.WriteLine(minValue.Peek());
                    }
                    break;
            }
        }

        Console.WriteLine(string.Join(", ", stackOfInts));
    }
}

