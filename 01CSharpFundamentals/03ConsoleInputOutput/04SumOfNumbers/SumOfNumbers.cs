using System;

class SumOfNumbers
{
    static void Main()
    {
        // 4. Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum.

        Console.Write("Input number: ");
        int numberN = int.Parse(Console.ReadLine());

        int sum = 0;

        for (int i = 0; i < numberN; i++)
        {
            sum += int.Parse(Console.ReadLine());
        }

        Console.WriteLine("The sum is: {0}", sum);
    }
}