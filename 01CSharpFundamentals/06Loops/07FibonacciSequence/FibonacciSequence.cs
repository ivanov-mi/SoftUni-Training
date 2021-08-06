using System;

class FibonacciSequence
{
    static void Main()
    {
        // 7. Write a program that reads a number N and calculates the sum of the first N
        //    members of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21 ...

        Console.Write("Input N: ");
        int number = int.Parse(Console.ReadLine());

        int sum = 0;
        int antepenultimate = 0;
        int previousNumber = 1;
        int tmp = 0;

        for (int i = 1; i <= number; i++)
        {
            sum += previousNumber;
            tmp = previousNumber;
            previousNumber += antepenultimate;
            antepenultimate = tmp;
        }

        Console.WriteLine("The sum of the first {0} Fibonacci numbers is: {1}", number, sum);
    }
}