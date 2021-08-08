using System;
using System.Globalization;

namespace GenericsExcercise
{
    class GenericCountMethodDoubles
    {
        static void Main()
        {
            var numberOfElements = int.Parse(Console.ReadLine());
            var listOfElements = new Box<double>();

            for (int i = 0; i < numberOfElements; i++)
            {
                var input = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                listOfElements.Values.Add(input);
            }

            var elementToCompare = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            var result = listOfElements.CountGreaterValues(elementToCompare);
            Console.WriteLine(result);
        }
    }
}
