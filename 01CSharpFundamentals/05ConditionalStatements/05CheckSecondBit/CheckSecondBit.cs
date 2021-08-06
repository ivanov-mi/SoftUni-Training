using System;

class CheckSecondBit
{
    static void Main()
    {
        // 5. Write a boolean expression for finding if the bit 2 (counting from 0) of a given integer is 1 or 0.

        Console.Write("Input a number: ");

        int number = int.Parse(Console.ReadLine());
        if ((number >> 2) % 2 == 1)
        {
            Console.WriteLine("Bit 2 of the number {0} is 1", number);
        }
        else
        {
            Console.WriteLine("Bit 2 of the number {0} is 0", number);
        }
    }
}