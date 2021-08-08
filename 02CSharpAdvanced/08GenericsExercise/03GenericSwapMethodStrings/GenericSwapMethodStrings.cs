using System;
using System.Linq;

namespace GenericsExcercise
{
    class GenericSwapMethodStrings
    {
        static void Main()
        {
            var numberOfString = int.Parse(Console.ReadLine());
            var box = new Box<string>();

            for (int i = 0; i < numberOfString; i++)
            {
                var input = Console.ReadLine();
                box.Values.Add(input);
            }

            var indexesToSwap = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var fisrIndex = indexesToSwap[0];
            var secondIndex = indexesToSwap[1];

            box.Swap(fisrIndex, secondIndex);

            Console.WriteLine(box);
        }
    }
}
