using System;

class BiggerNumber
{
    static void Main()
    {
        // 2. Write a program that gets two numbers from the console and prints
        //    the greater of them. Don`t use if statements.

        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());

        Console.WriteLine(Math.Max(firstNumber,secondNumber));
    }
}