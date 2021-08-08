using System;
using System.Collections.Generic;
using System.Linq;

class FashionBoutique
{
    static void Main()
    {
        var inputStack = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);
        Stack<int> stackOfClothes = new Stack<int>(inputStack);
        int rackCapacity = int.Parse(Console.ReadLine());
        int numberOfRacks = 1;
        int currentRackCapacity = rackCapacity;

        while (stackOfClothes.Count > 0)
        {
            int clothingValue = stackOfClothes.Pop();
            if (clothingValue <= currentRackCapacity)
            {
                currentRackCapacity -= clothingValue;
            }
            else
            {
                numberOfRacks++;
                currentRackCapacity = rackCapacity - clothingValue;
            }
        }

        Console.WriteLine(numberOfRacks);
    }
}

