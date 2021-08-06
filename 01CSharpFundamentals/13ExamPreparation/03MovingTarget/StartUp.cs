using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        List<int> targets = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();
        string inputLine = Console.ReadLine();

        while (inputLine?.ToLower() != "end")
        {
            string[] tokens = inputLine
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string comand = tokens[0];
            int index = int.Parse(tokens[1]);
            int value = int.Parse(tokens[2]);

            switch (comand?.ToLower())
            {
                case "shoot":
                    if (index >= 0 && index < targets.Count)
                    {
                        targets[index] -= value;

                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                    }
                    break;

                case "add":
                    if (index < 0 || index >= targets.Count)
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                    else
                    {
                        targets.Insert(index, value);
                    }
                    break;

                case "strike":
                    if ( (index - value) < 0 || (index + value) >= targets.Count)
                    {
                        Console.WriteLine("Strike missed!");
                    }
                    else
                    {
                        targets.RemoveRange((index - value), 2 * value + 1);
                    }
                    break;

                default:
                    break;
            }

            inputLine = Console.ReadLine();
        }

        Console.WriteLine(string.Join("|", targets));
    }
}