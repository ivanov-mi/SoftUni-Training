using System;

class CompareTwoCharArrays
{
    static void Main()
    {
        //03. Write a program that compares two char arrays lexicographically (letter by letter).

        string firstString = Console.ReadLine();
        string secondString = Console.ReadLine();
        int minElements = (int)Math.Min(firstString.Length, secondString.Length);
        bool isEqual = true;

        for (int i = 0; i < minElements; i++)
        {
            if (firstString[i] < secondString[i])
            {
                Console.WriteLine("{0}\n{1}", firstString, secondString);
                isEqual = false;
                break;
            }
            else if (firstString[i] > secondString[i])
            {
                Console.WriteLine("{0}\n{1}", secondString, firstString);
                isEqual = false;
                break;
            }
        }
        
        if (isEqual)
        {
            Console.WriteLine("The two strings are equal!");
        }
    }
}