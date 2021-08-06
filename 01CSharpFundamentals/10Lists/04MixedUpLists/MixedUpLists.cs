using System;
using System.Collections.Generic;
using System.Linq;

class MixedUpLists
{
    static void Main()
    {
        List<int> firstLine = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();
        List<int> secondLine = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        List<int> range = new List<int>(2);

        if (firstLine.Count > secondLine.Count)
        {
            range.AddRange(firstLine.GetRange(firstLine.Count - 2, 2));
            firstLine.RemoveRange(firstLine.Count - 2, 2);
        }
        else
        {
            range.AddRange(secondLine.GetRange(0, 2));
            secondLine.RemoveRange(0, 2);
        }

        List<int> mixedUpList = new List<int>(firstLine.Count + secondLine.Count);

        for (int i = 0; i < (firstLine.Count + secondLine.Count) / 2; i++)
        {
            mixedUpList.Add(firstLine[i]);
            mixedUpList.Add(secondLine[secondLine.Count - i -1]);
        }

        mixedUpList.Sort();
        range.Sort();

        foreach (var number in mixedUpList)
        {
            if (number > range[0] && number < range[1])
            {
                Console.Write($"{number} ");
            }
        }
    }
}