using System;
using System.Collections.Generic;

class MorseCode
{
    static void Main()
    {
        Dictionary<string, char> morseCodeTable = new Dictionary<string, char>
        {
            { ".-",      'A' },
            { "-...",    'B' },
            { "-.-.",    'C' },
            { "-..",     'D' },
            { ".",       'E' },
            { "..-.",    'F' },
            { "--.",     'G' },
            { "....",    'H' },
            { "..",      'I' },
            { ".---",    'J' },
            { "-.-",     'K' },
            { ".-..",    'L' },
            { "--",      'M' },
            { "-.",      'N' },
            { "---",     'O' },
            { ".--.",    'P' },
            { "--.-",    'Q' },
            { ".-.",     'R' },
            { "...",     'S' },
            { "-",       'T' },
            { "..-",     'U' },
            { "...-",    'V' },
            { ".--",     'W' },
            { "-..-",    'X' },
            { "-.--",    'Y' },
            { "--..",    'Z' },
            { "|",       ' ' }, 
        };

        string[] inputMessage = Console.ReadLine()
            .Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < inputMessage.Length; i++)
        {
            Console.Write($"{morseCodeTable[inputMessage[i]]}");
        }
    }
}