using System;
using System.Linq;

class ReverseAndExclude
{
    static void Main()
    {
        var numbers = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        var divisor = int.Parse(Console.ReadLine());

        Func<int, bool> predicate = x => x % divisor != 0;

        var output = numbers.Where(predicate).Reverse();

        Console.WriteLine(string.Join(" ", output));
    }
}

