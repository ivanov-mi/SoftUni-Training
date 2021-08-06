using System;
using System.Numerics;

class PrintNumbers
{
    static void Main()
    {
        // 5. Write a program that calculates N!*K!/(K-N)! for given N and K (1<N<K)

        Console.Write("Input N: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Input K: ");
        int k = int.Parse(Console.ReadLine());

        BigInteger factorial = 1;

        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
        }

        for (int i = (k - n + 1); i <= k; i++)
        {
            factorial *= i;
        }

        Console.WriteLine("N!*K!/(K-N)! = {0}", factorial);
    }
}