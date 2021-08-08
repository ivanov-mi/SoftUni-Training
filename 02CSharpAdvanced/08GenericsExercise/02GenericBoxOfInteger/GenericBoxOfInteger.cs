using System;

namespace GenericsExcercise
{
    class GenericBoxOfInteger
    {
        static void Main()
        {
            var numberOfInts = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInts; i++)
            {
                var input = int.Parse(Console.ReadLine());
                var box = new Box<int>(input);
                Console.WriteLine(box);
            }
        }
    }
}
