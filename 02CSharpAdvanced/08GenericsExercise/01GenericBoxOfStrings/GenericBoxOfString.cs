using System;

namespace GenericsExcercise
{
    class GenericBoxOfString
    {
        static void Main()
        {
            var numberOfString = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfString; i++)
            {
                var input = Console.ReadLine();
                var box = new Box<string>(input);
                Console.WriteLine(box);
            }
        }
    }
}
