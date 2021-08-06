using System;


class ExchangeNumbers
{
    static void Main()
    {
        // 1. Write an if statement that exchanges the value of 2 numbers if the first is bigger than the second.
        Console.Write("Input the first number: ");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.Write("Input the second number: ");
        int secondNumber = int.Parse(Console.ReadLine());
        int tmp;
        if (firstNumber > secondNumber)
        {
            tmp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = tmp;
        }
        Console.WriteLine("First number: {0} \nSecond number: {1}", firstNumber, secondNumber);
    }
}

