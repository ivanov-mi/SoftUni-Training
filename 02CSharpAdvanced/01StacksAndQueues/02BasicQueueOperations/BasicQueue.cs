using System;
using System.Collections.Generic;
using System.Linq;

class BasicQueue
{
    static void Main()
    {
        int[] elements = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int elementsToQueue = elements[0];
        int elementsToDequeue = elements[1];
        int searchedNumber = elements[2];

        Queue<int> basicQueue = new Queue<int>(elementsToQueue);

        int[] numbers = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        for (int i = 0; i < Math.Min(elementsToQueue, numbers.Length); i++)
        {
            basicQueue.Enqueue(numbers[i]);
        }

        for (int i = 0; i < elementsToDequeue; i++)
        {
            if (basicQueue.Count > 0)
            {
                basicQueue.Dequeue();
            }
        }

        if (basicQueue.Count == 0)
        {
            Console.WriteLine(0);
        }
        else if (basicQueue.Contains(searchedNumber))
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine(basicQueue.Min());
        }
    }
}

