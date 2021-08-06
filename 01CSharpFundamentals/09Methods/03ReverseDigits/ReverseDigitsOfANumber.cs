using System;

class ReverseDigitsOfANumber
{
    static void Main()
    {
        //03. Write a method that reverses the digits of given decimal number.
        //    Example: 256 -> 652

        Console.Write("Input decimal number: ");
        int inputNumber = int.Parse(Console.ReadLine());

        int reversedNumber = ReverseDigits(inputNumber);

        Console.WriteLine($"The reversed decimal number is: {reversedNumber}");
    }

    private static int ReverseDigits(int inputNumber)
    {
        int reversedNumber = 0;

        while (inputNumber != 0)
        {
            reversedNumber = reversedNumber * 10 + inputNumber % 10;
            inputNumber /= 10; 
        }

        return reversedNumber;
    }
}