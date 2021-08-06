using System;

class SordNumbers
{
    static void Main()
    {
        // 3. Sort 3 integer numbers using if statements.

        Console.Write("Input the first number: ");
        int firstNumber = int.Parse(Console.ReadLine());

        Console.Write("Input the second number: ");
        int secondNumber = int.Parse(Console.ReadLine());

        Console.Write("Input the third number: ");
        int thirdNumber = int.Parse(Console.ReadLine());

        int swapTemp;

        if (firstNumber > secondNumber)
        {
            swapTemp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = swapTemp;
        }

        if (firstNumber > thirdNumber)
        {
            swapTemp = firstNumber;
            firstNumber = thirdNumber;
            thirdNumber = swapTemp;
        }

        if (secondNumber > thirdNumber)
        {
            swapTemp = secondNumber;
            secondNumber = thirdNumber;
            thirdNumber = swapTemp;
        }

        Console.WriteLine("{0}, {1}, {2}", firstNumber, secondNumber, thirdNumber);
    }
}