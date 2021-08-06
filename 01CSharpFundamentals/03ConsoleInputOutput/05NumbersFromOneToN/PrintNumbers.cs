using System;

class PrintNumbers
{
    static void Main()
    {
        // 5. Write a program that reads an integer number n from the console and
        // prints all the numbers in the interval [1...n], each on a single line

        Console.Write("Input number: ");
        int numberN = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberN; i++)
        {
            Console.WriteLine(i+1);
        }   
    }
}