using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class StartUp
{
    static void Main()
    {
        string input = Console.ReadLine()
            .ToUpper();

        string pattern = @"(\D+)(\d+)";
        Regex splitRegex = new Regex(pattern);

        MatchCollection stringNumberPairs = splitRegex.Matches(input);

        StringBuilder sb = new StringBuilder();

        foreach (Match pair in stringNumberPairs)
        {
            string stringToRepeat = pair.Groups[1].Value;
            int repeatCount= int.Parse(pair.Groups[2].Value);

            for (int i = 0; i < repeatCount; i++)
            {
                sb.Append(stringToRepeat);
            }
        }

        string outputString = sb.ToString();
        int uniqueSymbolsCount = outputString
            .Distinct()
            .Count();

        Console.WriteLine($"Unique symbols used: {uniqueSymbolsCount}");
        Console.WriteLine($"{outputString}");
    }
}