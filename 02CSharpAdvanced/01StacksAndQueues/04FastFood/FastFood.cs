using System;
using System.Collections.Generic;
using System.Linq;

class FastFood
{
    static void Main()
    {
        int quantityOfFood = int.Parse(Console.ReadLine());
        var ordersInput = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);
        Queue<int> ordersQueue = new Queue<int>(ordersInput);
        bool unservedOrders = false;
        int maxOrder = int.MinValue;

        while (ordersQueue.Count > 0)
        {
            int currenOrder = ordersQueue.Peek();

            if (currenOrder > maxOrder)
            {
                maxOrder = currenOrder;
            }

            if (quantityOfFood >= currenOrder)
            {
                quantityOfFood -= currenOrder;
                ordersQueue.Dequeue();
            }
            else
            {
                unservedOrders = true;
                break;
            }
        }

        Console.WriteLine(maxOrder);
        if (unservedOrders == false)
        {
            Console.WriteLine("Orders complete");
        }
        else
        {
            Console.WriteLine($"Orders left: {string.Join(' ', ordersQueue)}");
        }
    }
}

