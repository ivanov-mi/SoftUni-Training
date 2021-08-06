using System;

class BiggestNumber
{
    static void Main()
    {
        // 2. Write a program that find the largest of 3 integers, using if statements.

        Console.Write("Input the first number: ");
        int firstNumber = int.Parse(Console.ReadLine());

        Console.Write("Input the second number: ");
        int secondNumber = int.Parse(Console.ReadLine());

        Console.Write("Input the third number: ");
        int thirdNumber = int.Parse(Console.ReadLine());

        int max = firstNumber;

        if (max < secondNumber)
        {
            max = secondNumber;
        }
        if (max < thirdNumber)
        {
            max = thirdNumber;
        }
        Console.WriteLine("The max value is: {0}", max);
    }
}