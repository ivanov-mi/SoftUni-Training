using System;
using System.Linq;

class KnightsOfHonor

{
    static void Main()
    {
        var names = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        Action<string> printSirAndName = name => Console.WriteLine($"Sir {name}");

        foreach (var name in names)
        {
            printSirAndName(name);
        }
    }
}

