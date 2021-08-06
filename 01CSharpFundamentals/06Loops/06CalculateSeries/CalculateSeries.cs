using System;

class CalculateSeries
{
    static void Main()
    {
        // 6. Write a program that, for given two integer numbers N and X, calculates the sum
        //    S = 1 + 1!/X + 2!/X^2 + ... + N!/X^N

        Console.Write("Input N: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Input X: ");
        int x = int.Parse(Console.ReadLine());

        double sum = 1;
        double power = 1;
        double factorial = 1;

        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
            power *= x;
            sum += factorial / power;
        }

        Console.WriteLine("S = 1 + 1!/X + 2!/X^2 + ... + N!/X^N! = {0}", sum);
    }
}