using System;
using System.Collections.Generic;

class CountSymbols
{
    static void Main()
    {
        string text = Console.ReadLine();
        var letters = new SortedDictionary<char, int>();

        foreach (var ch in text)
        {
            if (!letters.ContainsKey(ch))
            {
                letters.Add(ch, 0);
            }

            letters[ch]++;
        }

        foreach (var ch in letters)
        {
            Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
        }
    }
}

