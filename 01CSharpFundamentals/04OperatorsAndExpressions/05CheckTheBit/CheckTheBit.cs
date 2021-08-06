using System;

class CheckTheBit
{
    static void Main()
    {
        // 5. Write a boolean expression for finding if the bit 2 (counting from 0) of a given integer is 1 or 0.

        int checkTheBit = int.Parse(Console.ReadLine());

        Console.WriteLine("Bit 2 ot the integer is: {0}", (checkTheBit >> 2) % 2);
    }
}