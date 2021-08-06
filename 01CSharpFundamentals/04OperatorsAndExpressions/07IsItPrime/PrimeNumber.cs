using System;

class PrimeNumber
{
    static void Main()
    {
        // 7. Write an expression that ckecks if given positive integer n<=100 is prime.

        Console.Write("Input integer between 1 and 100: ");
        int integerToCheck = int.Parse(Console.ReadLine());

        bool isItPrime = true;

        if (integerToCheck < 2)
        {
            isItPrime = false;
        }
        else if (integerToCheck == 2)
        {
            isItPrime = true;
        }
        else if (integerToCheck % 2 == 0)
        {
            isItPrime = false;
        }
        else
        {
            int upperBound = (int)Math.Sqrt(integerToCheck);

            for (int i = 3; i <= upperBound; i+=2)
            {
                if (integerToCheck % i == 0)
                {
                    isItPrime = false;
                    break;
                }
            }
        }

        Console.WriteLine("Number {0} is prime: {1}", integerToCheck,isItPrime);
    }
}