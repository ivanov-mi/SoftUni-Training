using System;
using System.Linq;

class PredicateParty
{
    static void Main()
    {
        var names = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        string commandLine = string.Empty;

        while ((commandLine = Console.ReadLine())?.ToLower() != "party!")
        {
            var commands = commandLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var command = commands[0];
            var filter = commands[1];
            var filterParameter = commands[2];

            var filterNames = names.Where(FilterFunc(filter, filterParameter)).ToList();

            if (command?.ToLower() == "double")
            {
                foreach (var name in filterNames)
                {
                    var index = names.IndexOf(name);
                    names.Insert(index, name);
                }
            }
            else if (command?.ToLower() == "remove")
            {
                names.RemoveAll(x => filterNames.Contains(x));
            }
        }
        if (names.Count == 0)
        {
            Console.WriteLine($"Nobody is going to the party!");
        }
        else
        {
            Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
        }
    }

    private static Func<string, bool> FilterFunc(string criteria, string pattern)
    {
        if (criteria?.ToLower() == "startswith")
        {
            return x => x.StartsWith(pattern);
        }
        else if (criteria?.ToLower() == "endswith")
        {
            return x => x.EndsWith(pattern);
        }
        else if (criteria?.ToLower() == "length")
        {
            return x => x.Length == int.Parse(pattern);
        }

        return x => true;
    }
}

