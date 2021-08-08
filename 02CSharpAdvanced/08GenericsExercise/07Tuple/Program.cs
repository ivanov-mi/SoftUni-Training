using System;
using System.Globalization;
using System.Text;

namespace GenericsExcercise
{
    class Program
    {
        static void Main()
        {
            var inputPersonInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var firstAndLastNames = inputPersonInfo[0] + " " + inputPersonInfo[1];
            var address = inputPersonInfo[2];
            var personInfo = new MyTuple<string, string>(firstAndLastNames, address);

            var inputBeerPerson = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var name = inputBeerPerson[0];
            var littresOfBeer = int.Parse(inputBeerPerson[1]);
            var beerPerson = new MyTuple<string, int>(name, littresOfBeer);

            var inputNumbersInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var intNumber = int.Parse(inputNumbersInfo[0]);
            var doubleNumber = double.Parse(inputNumbersInfo[1], CultureInfo.InvariantCulture);
            var numbersInfo = new MyTuple<int, double>(intNumber, doubleNumber);

            var result = new StringBuilder();
            result.AppendLine(personInfo.ToString());
            result.AppendLine(beerPerson.ToString());
            result.AppendLine(numbersInfo.ToString());

            Console.WriteLine(result);
        }
    }
}
