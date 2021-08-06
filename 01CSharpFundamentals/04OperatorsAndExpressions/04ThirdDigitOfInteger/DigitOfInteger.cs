using System;

class DigitOfInteger
{
    static void Main()
    {
        // 4. Write an expression to check if the 3rd digit of an integer is 3. 
        //    e.g. 2351 -> true

        int checkaNumber = int.Parse(Console.ReadLine());

        Console.WriteLine((checkaNumber / 100) % 10 == 3);
    }
}