using System;
using System.Linq;

class ListOfPredicates
{
    static void Main()
    {
        var endOfSequence = int.Parse(Console.ReadLine());
        var divisors = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var sequenceOfNumbers = Enumerable.Range(1, endOfSequence);

        foreach (var divider in divisors)
        {
            Func<int, bool> isDivided = x => x % divider == 0;

            sequenceOfNumbers = sequenceOfNumbers.Where(isDivided);
        }

        Console.WriteLine(string.Join(" ", sequenceOfNumbers));
    }
}

