using System;
using System.Linq;

class AppliedArithmetics
{
    static void Main()
    {
        var numbers = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);

        Func<int, int> addFunc = x => x += 1;
        Func<int, int> multiplyFunc = x => x *=2;
        Func<int, int> subtractFunc = x => x -= 1;
        Action<int[]> print = numbers => Console.WriteLine(string.Join(" ", numbers));

        string commands = string.Empty;

        while ((commands = Console.ReadLine())?.ToLower() != "end")
        {
            switch (commands)
            {
                case "add":
                    numbers = numbers.Select(addFunc);
                    break;
                case "multiply":
                    numbers = numbers.Select(multiplyFunc);
                    break;
                case "subtract":
                    numbers = numbers.Select(subtractFunc);
                    break;
                case "print":
                    print(numbers.ToArray());
                    break;
                default:
                    break;
            }
        }
    }
}

