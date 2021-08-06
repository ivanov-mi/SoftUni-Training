using System;

class Sumator
{
    static void Main()
    {
        string firstInputLine = Console.ReadLine();
        char firstChar = firstInputLine[0];

        string secondInputLine = Console.ReadLine();
        char secondChar = secondInputLine[0];

        string inputString = Console.ReadLine();

        int sum = 0;

        foreach (var ch in inputString)
        {
            if ((ch < firstChar && ch > secondChar) || (ch > firstChar && ch < secondChar))
            {
                sum += ch;
            }
        }

        Console.WriteLine(sum);
    }
}