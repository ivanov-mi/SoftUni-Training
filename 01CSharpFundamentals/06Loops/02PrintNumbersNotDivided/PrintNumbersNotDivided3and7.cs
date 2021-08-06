using System;

class PrintNumbersNotDivided3and7
{
    static void Main()
    {
        // 2.Write a program that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time.

        Console.Write("Input N: ");
        int number = int.Parse(Console.ReadLine());

        for (int i = 1; i <= number; i++)
        {
            if (i % 3 == 0 && i % 7 == 0)
            {
                continue;
            }

            Console.WriteLine(i);
        }
    }
}