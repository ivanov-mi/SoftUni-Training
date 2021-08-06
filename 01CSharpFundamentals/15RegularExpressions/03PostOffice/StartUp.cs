using System;
using System.Linq;
using System.Text.RegularExpressions;

class StartUp
{
    static void Main()
    {
        string[] inputLine = Console.ReadLine()
            .Split('|', StringSplitOptions.RemoveEmptyEntries);

        string firstPartString = inputLine[0];
        string secondPartString = inputLine[1];
        string thirdPartString = inputLine[2];

        Regex capitalLettersRegex = new Regex(@"([#$%*&])([A-Z]+)\1");
        Match lettersMatch = capitalLettersRegex.Match(firstPartString);

        string capitalLetters = lettersMatch.Groups[2].Value;

        Regex wordLengthRegex = new Regex(@"(\d{2}):(\d{2})");
        MatchCollection wordLengthMatches = wordLengthRegex.Matches(secondPartString);

        string[] wordLengths = wordLengthMatches
            .Select(x => x.Value)
            .Distinct()
            .ToArray();

        foreach (var ch in capitalLetters)
        {
            string[] capitalLettersWordLengthPairs = wordLengths
                .Where(x => x.StartsWith(((int)ch)
                .ToString()))
                .ToArray();

            foreach (var pair in capitalLettersWordLengthPairs)
            {
                int wordLength = int.Parse(pair.Substring(3,2));

                Regex extractedWordRegex = new Regex($"((?<=\\s)|\\A){ch}\\S{{{wordLength}}}((?=\\s)|\\z)");
                MatchCollection extractedWords = extractedWordRegex.Matches(thirdPartString);

                foreach (var word in extractedWords)
                {
                        Console.WriteLine(word);
                }
            }
        }
    }
}