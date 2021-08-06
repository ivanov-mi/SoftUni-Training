using System;

class OddOrEven
{
    static void Main()
    {
        // 1. Write an expression that checks if given integer is odd or even.
        int oddOrEven = int.Parse(Console.ReadLine());
        if (oddOrEven % 2 == 0)
        {
            Console.WriteLine("The integer {0} is even", oddOrEven);
        }
        else Console.WriteLine("The integer {0} is odd", oddOrEven);     
    }
}
