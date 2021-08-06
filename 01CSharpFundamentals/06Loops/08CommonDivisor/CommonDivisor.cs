using System;

class CommonDivisor
{
    static void Main()
    {
        // 8. Write a program that calculates the greatest common divisor (GCD) of given two numbers.
        //    Use the Euclidean algorithm (find it in internet).

        Console.Write("Input the first number: ");
        int firstNumber = int.Parse(Console.ReadLine());

        Console.Write("Input the second number: ");
        int secondNumber = int.Parse(Console.ReadLine());

        while(secondNumber!=0)
        {
            int tmp = secondNumber;
            secondNumber = firstNumber % secondNumber;
            firstNumber = tmp;

        }
        Console.WriteLine("The greatest common divisor is {0}", firstNumber);
    }
}