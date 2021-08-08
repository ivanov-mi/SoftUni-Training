using System;

class ActionPoint
{
    static void Main()
    {
        var names = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        Action<string[]> printNames = x => Console.WriteLine(string.Join(Environment.NewLine, names));

        printNames(names);
    }
}

