using System;
using System.Collections.Generic;
using System.Linq;

class TruckTour
{
    static void Main()
    {
        int numberOfPumps = int.Parse(Console.ReadLine());
        Queue<int> petrolPumps = new Queue<int>(numberOfPumps);

        for (int i = 0; i < numberOfPumps; i++)
        {
            int[] inputLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int amountOfPetrol = inputLine[0];
            int distance = inputLine[1];
            int remainderToNextPump = amountOfPetrol - distance;

            petrolPumps.Enqueue(remainderToNextPump);
        }

        for (int i = 0; i < numberOfPumps; i++)
        {
            Queue<int> currentStartQueue = new Queue<int>(petrolPumps);
            int amountOfFuel = currentStartQueue.Peek();
            int numberOfPupsVisited = 0;

            while (amountOfFuel >= 0)
            {
                currentStartQueue.Enqueue(currentStartQueue.Dequeue());

                amountOfFuel += currentStartQueue.Peek();
                numberOfPupsVisited++;
                if (numberOfPupsVisited == numberOfPumps)
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            petrolPumps.Enqueue(petrolPumps.Dequeue());
        }
    }
}

