using System;
using System.Collections.Generic;

class Crossroads
{
    static void Main()
    {
        int greenDuration = int.Parse(Console.ReadLine());
        int freeWindowDuration = int.Parse(Console.ReadLine());
        Queue<string> crossroadQueue = new Queue<string>();
        int numberOfCarsPassed = 0;

        while (true)
        {
            string input = Console.ReadLine();

            if (input.ToLower() == "end")
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{numberOfCarsPassed} total cars passed the crossroads.");
                return;
            }
            else if (input.ToLower() == "green")
            {
                int remainingTimeGreen = greenDuration;

                while (remainingTimeGreen > 0 && crossroadQueue.Count > 0)
                {
                    string car = crossroadQueue.Dequeue();

                    if (remainingTimeGreen > car.Length)
                    {
                        remainingTimeGreen -= car.Length;
                        numberOfCarsPassed++;

                    }
                    else if ((remainingTimeGreen + freeWindowDuration) >= car.Length)
                    {
                        numberOfCarsPassed++;
                        break;
                    }
                    else
                    {
                        char carHittedPart = car[remainingTimeGreen + freeWindowDuration];
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{car} was hit at {carHittedPart}.");
                        return;
                    }
                }
            }
            else
            {
                crossroadQueue.Enqueue(input);
            }
        }
    }
}

