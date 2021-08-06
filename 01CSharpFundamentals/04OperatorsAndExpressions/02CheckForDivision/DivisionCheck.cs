using System;

class DivisionCheck
{
    static void Main()
    {
        // 2. Write a boolean expression that checks if an integer can be divided by 2, 3 and 5 witout remainder (use logical operators).

        int numberToCheck = int.Parse(Console.ReadLine());
        if (numberToCheck % 2 == 0)
        {
            Console.WriteLine("The number {0} is divided by 2 without remainder", numberToCheck);
        }
        else
        {
            Console.WriteLine("The numbes {0} can`t be dividided by 2 without remainder", numberToCheck);
        }
        if (numberToCheck % 3 == 0)
        {
            Console.WriteLine("The number {0} is divided by 3 without remainder", numberToCheck);
        }
        else
        {
            Console.WriteLine("The numbes {0} can`t be dividided by 3 without remainder", numberToCheck);
        }
        if (numberToCheck % 5 == 0)
        {
            Console.WriteLine("The number {0} is divided by 5 without remainder", numberToCheck);
        }
        else
        {
            Console.WriteLine("The number {0} can`t be dividided by 5 without remainder", numberToCheck);
        }
    }
}