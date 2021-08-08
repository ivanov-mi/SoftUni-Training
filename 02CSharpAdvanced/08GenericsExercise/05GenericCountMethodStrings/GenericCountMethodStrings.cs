using System;

namespace GenericsExcercise
{
    class GenericCountMethodStrings
    {
        static void Main()
        {
            var numberOfElements = int.Parse(Console.ReadLine());
            var listOfElements = new Box<string>();

            for (int i = 0; i < numberOfElements; i++)
            {
                var input = Console.ReadLine();
                listOfElements.Values.Add(input);
            }

            var elementToCompare = Console.ReadLine();
            var result = listOfElements.CountGreaterValues(elementToCompare);
            Console.WriteLine(result);
        }
    }
}
