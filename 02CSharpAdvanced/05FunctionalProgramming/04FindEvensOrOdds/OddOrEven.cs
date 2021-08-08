using System;
using System.Linq;

class OddOrEven
{
    static void Main()
    {
        var bounds = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        var condition = Console.ReadLine();

        int lowerBound = bounds[0];
        int upperBound = bounds[1];

        Predicate<int> checkNumber = IsOddOrEven(condition);

        var output = Enumerable.Range(lowerBound, (upperBound - lowerBound + 1)).Where(x => checkNumber(x));

        Console.WriteLine(string.Join(" ", output));
    }

    private static Predicate<int> IsOddOrEven(string condition)
    {
        Predicate<int> checkNumber;

        if (condition == "odd")
        {
            checkNumber = x => x % 2 != 0;
        }
        else if (condition == "even")
        {
            checkNumber = x => x % 2 == 0;
        }
        else
        {
            checkNumber = x => true;
        }

        return checkNumber;
    }
}

