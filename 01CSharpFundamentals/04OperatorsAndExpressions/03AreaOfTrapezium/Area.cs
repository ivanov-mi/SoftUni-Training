using System;

class Area
{
    static void Main()
    {
        // 3. Write a program that evalueates the area of a trapezium, given its sides and height.

        Console.Write("Enter value of a: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Enter value of b: ");
        int b = int.Parse(Console.ReadLine());

        Console.Write("Enter value of h: ");
        int h = int.Parse(Console.ReadLine());

        Console.WriteLine("The area of the trapezium is: {0}", (a+b) * h / 2);
    }
}