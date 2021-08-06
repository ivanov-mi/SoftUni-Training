using System;
using System.Numerics;

class CalculateCombinations
{
    static void Main()
    {
        // 4. Write a program that calculates N!/K! for given N and K (1<K<N).

        Console.Write("Input N: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Input K: ");
        int k = int.Parse(Console.ReadLine());

        BigInteger factorial = 1;

        for (int i = k+1; i <=n; i++)
        {
            factorial *= i;
        }

        Console.WriteLine("N!/K! = {0}", factorial);
    }
}