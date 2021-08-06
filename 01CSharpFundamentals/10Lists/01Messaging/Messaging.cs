using System;
using System.Collections.Generic;
using System.Linq;

class Messaging
{
    static void Main()
    {
        int[] inputNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

        List<char> charsOfMessage = Console.ReadLine().ToCharArray().ToList();

        for (int i = 0; i < inputNumbers.Length; i++)
        {
            int outputIndex = sumOfDigits(inputNumbers[i]) % charsOfMessage.Count;
            Console.Write(charsOfMessage[outputIndex]);
            charsOfMessage.RemoveAt(outputIndex);
        }
    }

    private static int sumOfDigits(int number)
    {
        int result = 0;
        while (number != 0)
        {
            result += number % 10;
            number /= 10; 
        }
        return result;
    }
}