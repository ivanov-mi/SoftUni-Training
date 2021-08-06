using System;

class QuadraticEquation
{
    static void Main()
    {
        // 3. Write a program that reads the coefficients a, b and c of a q quardratic equation
        //    ax^2 + bx + c = 0 and solves it (prints its real roots).

        Console.Write("Quadratic equation ax^2 + bx + c = 0 solver \nInput coefficient a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Input coefficient b: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Input coefficient c: ");
        double c = double.Parse(Console.ReadLine());

        double D = b * b - 4 * a * c;

        if(D < 0)
        {
            Console.WriteLine("There are no real roots!");
        }
        else if(D == 0)
        {
            Console.WriteLine("x1=x2={0}", (-b / (2 * a)));
        }
        else
        {
            Console.WriteLine("x1={0} \nx2={1}", (-b+Math.Sqrt(D) / (2*  a)), (-b - Math.Sqrt(D) / (2 * a)));
        }
    }
}