using System;
using System.Collections.Generic;
using System.Linq;

class FilterModule
{
    static void Main()
    {
        var names = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        var commandsList = new List<string>();
        string commandLine = string.Empty;

        while ((commandLine = Console.ReadLine())?.ToLower() != "print")
        {
            if (commandLine.StartsWith("Remove", StringComparison.CurrentCultureIgnoreCase))
            {
                var command = commandLine.Replace("remove", "add", StringComparison.CurrentCultureIgnoreCase);
                commandsList.RemoveAll(x => x.Equals(command, StringComparison.CurrentCultureIgnoreCase));
            }
            else
            {
                commandsList.Add(commandLine);
            }
        }

        foreach (var line in commandsList)
        {
            var commands = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
            var filterType = commands[1];
            var filterParameter = commands[2];

            var filterNames = names.Where(FilterFunc(filterType, filterParameter)).ToList();

            names.RemoveAll(x => filterNames.Contains(x));
        }

        if (names.Any())
        {
            Console.WriteLine( string.Join(" ", names));
        }
    }

    private static Func<string, bool> FilterFunc(string criteria, string pattern)
    {
        if (criteria?.ToLower() == "starts with")
        {
            return x => x.StartsWith(pattern);
        }
        else if (criteria?.ToLower() == "ends with")
        {
            return x => x.EndsWith(pattern);
        }
        else if (criteria?.ToLower() == "length")
        {
            return x => x.Length == int.Parse(pattern);
        }
        else if (criteria?.ToLower() == "contains")
        {
            return x => x.Contains(pattern);
        }

        return x => true;
    }
}
