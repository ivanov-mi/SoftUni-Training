using System;

class CheckBitPositionP
{
    static void Main()
    {
        // 8. Write a Boolean expression that returns if the bit at position p (counting from 0) in a given integer v has a value 1.

        Console.Write("Input a number: ");
        int integerV = int.Parse(Console.ReadLine());

        Console.Write("Input a bit position to check: ");
        int bitPosition = int.Parse(Console.ReadLine());

        Console.WriteLine((integerV >> bitPosition) % 2 == 1);
    }
}