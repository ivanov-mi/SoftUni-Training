using System;

class CompareFloat
{
    static void Main()
    {
        // 2. Read two floating point numbers from the console. Write a program to successfully
        //    compare these floating point numbers with precision of 0.00001.
        //    e.g. 3.0006 and 3.1 false, 3.000007 and 3.000008 true.
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());
        Console.WriteLine((Math.Abs(firstNumber - secondNumber) <= 0.00001));     
    }
}