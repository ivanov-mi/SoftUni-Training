using System;

class PrintNumbers
{
    static void Main()
    {
        // 1. Write a program that prints all the numbers from 1 to N.

        Console.Write("Input N: ");
        int number = int.Parse(Console.ReadLine());

        for (int i = 1; i <= number; i++)
        {
            Console.WriteLine(i);
        }
    }
}