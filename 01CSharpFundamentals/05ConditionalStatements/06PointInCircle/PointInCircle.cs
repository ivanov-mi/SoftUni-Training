using System;

class PointInCircle
{
    static void Main()
    {
        // 6. Write an expression that checks if a given point (x,y) is within a circle with radius 4 and centre at (0,0).

        Console.Write("x=");
        int coordinateX = int.Parse(Console.ReadLine());

        Console.Write("y=");
        int coordinateY = int.Parse(Console.ReadLine());

        if ((coordinateX * coordinateX + coordinateY * coordinateY) <= 16)
        {
            Console.WriteLine("Point with coordinate ({0},{1}) is within a circle with radius 4 and centre of (0,0)", coordinateX, coordinateY);
        }
        else
        {
            Console.WriteLine("Point with coordinate ({0},{1}) is outside a circle with radius 4 and centre of (0,0)", coordinateX, coordinateY);
        }
    }
}