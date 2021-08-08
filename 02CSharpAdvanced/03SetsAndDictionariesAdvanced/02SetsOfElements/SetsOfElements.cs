using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SetsOfElements
{
    static void Main()
    {
        var inputNumbersOFElements = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        int n = inputNumbersOFElements[0];
        var firstSet = new HashSet<int>(n);
        int m = inputNumbersOFElements[1];
        var secondSet = new HashSet<int>(m);

        for (int i = 0; i < n; i++)
        {
            firstSet.Add(int.Parse(Console.ReadLine()));
        }

        for (int i = 0; i < m; i++)
        {
            secondSet.Add(int.Parse(Console.ReadLine()));
        }

        Console.WriteLine(string.Join(" ", firstSet.Intersect(secondSet)));       
    }
}

