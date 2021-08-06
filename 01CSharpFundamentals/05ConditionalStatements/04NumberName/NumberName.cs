using System;

class NumberName
{
    static void Main()
    {
        // 4. Write a program that enters a number from 10 to 19 and prints on the console the name of the number. Use switch.
        //    e.g. 11 - "eleven"

        int number = int.Parse(Console.ReadLine());

        switch (number)
        {
            case 10: Console.WriteLine("Ten"); break;
            case 11: Console.WriteLine("Eleven"); break;
            case 12: Console.WriteLine("Twelve"); break;
            case 13: Console.WriteLine("Thirheen"); break;
            case 14: Console.WriteLine("Fourteen"); break;
            case 15: Console.WriteLine("Fifteen"); break;
            case 16: Console.WriteLine("Sixteen"); break;
            case 17: Console.WriteLine("Seventeen"); break;
            case 18: Console.WriteLine("Eighteen"); break;
            case 19: Console.WriteLine("Nineteen"); break;
            default:
                Console.WriteLine("Out of range!");
                break;
        }
    }
}