using System;
using System.Collections.Generic;

class EvenTimes
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var collectionOfNumbers = new Dictionary<int, int>();

        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());

            if (!collectionOfNumbers.ContainsKey(number))
            {
                collectionOfNumbers.Add(number, 0);
            }

            collectionOfNumbers[number]++;
        }

        foreach (var number in collectionOfNumbers)
        {
            if (number.Value % 2 == 0)
            {
                Console.WriteLine(number.Key);
            }
        }

    }
}

