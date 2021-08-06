using System;

class DivisionOfFive
{
    static void Main()
    {
        // 1. Write a program that reads two positive integer numbers and prints how many numbers p exist between 
        //     them such that the remainder of the division with p by 5 is 0 (inclusive). Example: p(17,25) = 2 

        int firstEndpoint = int.Parse(Console.ReadLine());
        int secondEndpoint = int.Parse(Console.ReadLine());
        int numbers = Math.Abs(firstEndpoint - secondEndpoint) / 5;

        if (firstEndpoint % 5 ==0 || secondEndpoint % 5 == 0)
        {
            numbers++;
        }

        Console.WriteLine("p({0},{1}) = {2}", firstEndpoint, secondEndpoint, numbers);
    }
}