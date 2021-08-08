using System;
using System.Collections.Generic;

class PeriodicTable
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var periodicTable = new SortedSet<string>();

        for (int i = 0; i < n; i++)
        {
            var inputLine = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var chemicalCompound in inputLine)
            {
                periodicTable.Add(chemicalCompound);
            }
        }

        Console.WriteLine(string.Join(' ', periodicTable));
    }
}

