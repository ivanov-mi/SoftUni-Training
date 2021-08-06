using System;
using System.Linq;
using System.Text.RegularExpressions;

class StartUp
{
    static void Main()
    {
        string inputLine = Console.ReadLine();
        string digitsRegex = @"[\d]";

        MatchCollection coolThresholdDigits = Regex.Matches(inputLine, digitsRegex);

        long coolThreshold = coolThresholdDigits.Select(x => int.Parse(x.Value))
            .Aggregate((x,y) => x*y);

        string emojiRegex = @"(::|\*\*)(?<emoji>[A-Z][a-z]{2,})\1";

        MatchCollection emojis = Regex.Matches(inputLine, emojiRegex);

        int foundEmojis = emojis.Count;
        var coolEmojis = emojis.Where(x => (x.Groups["emoji"].ToString().Sum(ch => (int)ch)) > coolThreshold);

        Console.WriteLine($"Cool threshold: {coolThreshold}");
        Console.WriteLine($"{foundEmojis} emojis found in the text. The cool ones are:");

        foreach (var emoji in coolEmojis)
        {
            Console.WriteLine(emoji);
        }     
    }
}