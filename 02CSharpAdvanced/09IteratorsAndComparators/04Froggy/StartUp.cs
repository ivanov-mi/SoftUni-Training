using System;
using System.Linq;

namespace IteratorsAndComparators
{
    class StartUp
    {
        static void Main()
        {
            var stones = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var lake = new Lake(stones);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}