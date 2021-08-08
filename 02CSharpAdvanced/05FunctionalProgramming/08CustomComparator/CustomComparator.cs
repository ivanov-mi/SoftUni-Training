using System;
using System.Linq;

class CustomComparator
{
    static void Main()
    {
        var numbers = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Func<int, int, int> customComparer = (x, y) =>
        {
            if (x % 2 == 0 && y % 2 !=0)
            {
                return -1;
            }
            else if (x % 2 != 0 && y % 2 == 0)
            {
                return 1;
            }
            else if(x < y)
            {
                return -1;
            }
            else if(x > y)
            {
                return 1;
            }

            return 0;
        };

        Array.Sort(numbers, (x, y) => customComparer(x, y));

        Console.WriteLine(string.Join(" ", numbers));
    }
}

