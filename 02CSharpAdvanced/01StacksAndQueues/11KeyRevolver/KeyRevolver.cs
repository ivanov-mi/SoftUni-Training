using System;
using System.Collections.Generic;
using System.Linq;

class KeyRevolver
{
    static void Main()
    {
        int priceOfBullet = int.Parse(Console.ReadLine());
        int gunBarrel = int.Parse(Console.ReadLine());
        var inputBullets = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);
        Stack<int> bullets = new Stack<int>(inputBullets);
        var inputLocks = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);
        Queue<int> locks = new Queue<int>(inputLocks);
        int valueOfintelligence = int.Parse(Console.ReadLine());

        int usedBullets = 0;

        while (locks.Count > 0 && bullets.Count > 0)
        {     
            int currentLock = locks.Peek();
            int currentBullet = bullets.Pop();
            usedBullets++;

            if (currentBullet <= currentLock)
            {
                Console.WriteLine("Bang!");
                locks.Dequeue();
            }
            else
            {
                Console.WriteLine("Ping!");
            }

            if ((usedBullets) % gunBarrel == 0 && bullets.Count > 0)
            {
                Console.WriteLine("Reloading!");
            }
        }

        if (locks.Count == 0)
        {
            int earnedMoney = valueOfintelligence - usedBullets * priceOfBullet;
            Console.WriteLine($"{bullets.Count} bullets left. Earned ${earnedMoney}");
        }
        else
        {
            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        }
    }
}

