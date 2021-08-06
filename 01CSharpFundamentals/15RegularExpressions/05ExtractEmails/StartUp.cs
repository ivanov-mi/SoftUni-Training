using System;
using System.Text.RegularExpressions;

class StartUp
{
    static void Main()
    {
        string inputLine = Console.ReadLine();

        string pattern = @"(?<=\s)([a-zA-Z0-9]+[[a-zA-Z0-9\.\-_]*[[a-zA-Z0-9]+@[a-z]+[a-z\.\-]*[\.][a-z]+)";

        Regex emailRegex = new Regex(pattern);

        MatchCollection emailMatches = emailRegex.Matches(inputLine);

        foreach (Match email in emailMatches)
        {
            Console.WriteLine(email.Value);
        }
    }
}