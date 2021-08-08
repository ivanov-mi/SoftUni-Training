using System;
using System.Linq;

class MinFunc
{
    static void Main()
    {
        var setOfIntegers = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Func<int[], int> min = numbers =>
        {
            int minValue = int.MaxValue;

            foreach (var currentNumber in numbers)
            {
                if (minValue > currentNumber)
                {
                    minValue = currentNumber;
                }
            }

            return minValue;
        };

        Console.WriteLine(min(setOfIntegers));
    }
}
