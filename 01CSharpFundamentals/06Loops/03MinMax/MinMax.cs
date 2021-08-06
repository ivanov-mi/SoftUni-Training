using System;

class MinMax
{
    static void Main()
    {
        // 3. Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.

        Console.Write("Input number of integers: ");
        int n = int.Parse(Console.ReadLine());

        int min = Int32.MaxValue;
        int max = Int32.MinValue;
        int inputValue;

        for (int i = 0; i < n; i++)
        {
            inputValue = int.Parse(Console.ReadLine());

            if(min > inputValue)
            {
                min = inputValue;
            }

            if (max < inputValue)
            {
                max = inputValue;
            }
        }

        Console.WriteLine("The minimum value is: {0} and the maximum values is: {1}", min, max);
    }
}