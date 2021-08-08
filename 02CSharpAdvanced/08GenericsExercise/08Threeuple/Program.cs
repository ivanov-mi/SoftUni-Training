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
            var sb = new StringBuilder();
            for (int i = 3; i < inputPersonInfo.Length; i++)
            {
                sb.Append(inputPersonInfo[i]);
                sb.Append(" ");
            }
            var cityName = sb.ToString();
            var personInfo = new Threeuple<string, string, string>(firstAndLastNames, address, cityName);

            var inputBeerPerson = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var name = inputBeerPerson[0];
            var littresOfBeer = int.Parse(inputBeerPerson[1]);
            var isDrunk = false;
            if (inputBeerPerson[2].ToLower() == "drunk")
            {
                isDrunk = true;
            }
            var beerPerson = new Threeuple<string, int, bool>(name, littresOfBeer, isDrunk);

            var inputBankAccount = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var accouuntName = inputBankAccount[0];
            var doubleBalance = double.Parse(inputBankAccount[1], CultureInfo.InvariantCulture);
            var bankName = inputBankAccount[2];
            var bankAccountInfo = new Threeuple<string, double, string>(accouuntName, doubleBalance, bankName);

            var result = new StringBuilder();
            result.AppendLine(personInfo.ToString());
            result.AppendLine(beerPerson.ToString());
            result.AppendLine(bankAccountInfo.ToString());

            Console.WriteLine(result);
        }
    }
}
