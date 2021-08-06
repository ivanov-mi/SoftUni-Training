using System;

class PrintAMatrix
{
    static void Main()
    {
        //// 10. Write a program that reads from the console a positive integer 
        ///      number N (N<20) and outputs a matrix like the following:
        //         N=3              N=4
        //        1 2 3           1 2 3 4
        //        2 3 4           2 3 4 5
        //        4 5 6           3 4 5 6
        //                        4 5 6 7

        Console.Write("Input matrix dimension (N<20): ");
        int size = int.Parse(Console.ReadLine());

        for (int i = 0; i < size; i++)
        {
            for (int j = i; j < (size + i); j++)
            {
                Console.Write("{0, 3}", j+1);

            }
            Console.WriteLine();
        }

        for (int i = 0; i < 3;)
        {
            Console.WriteLine("a");
        }
    }
}