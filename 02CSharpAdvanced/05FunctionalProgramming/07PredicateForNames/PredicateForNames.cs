using System;
using System.Linq;

class PredicateForNames
{
    static void Main()
    {
        var nameLength = int.Parse(Console.ReadLine());
        var names = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        Func<string, bool> filterNames = x => x.Length <= nameLength;

        Console.WriteLine(string.Join(Environment.NewLine, names.Where(filterNames)));
    }
}
