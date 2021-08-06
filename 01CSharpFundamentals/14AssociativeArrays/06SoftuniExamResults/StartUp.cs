using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        Dictionary<string, int> results = new Dictionary<string, int>();
        Dictionary<string, int> submissions = new Dictionary<string, int>();

        string input = string.Empty;

        while ((input = Console.ReadLine()) != "exam finished")
        {
            string[] tokens = input.Split('-', StringSplitOptions.RemoveEmptyEntries);
            string username = tokens[0];

            if (tokens[1].ToLower() != "banned")
            {
                string language = tokens[1];
                int points = int.Parse(tokens[2]);

                if (results.ContainsKey(username) == false)
                {
                    results.Add(username, points);
                }
                else
                {
                    if (results[username] < points)
                    {
                        results[username] = points;
                    }
                }

                if (submissions.ContainsKey(language) == false)
                {
                    submissions.Add(language, 0);
                }
                submissions[language]++;
            }
            else
            {
                results.Remove(username);
            }
        }

        Console.WriteLine("Results:");

        foreach(var participant in results.OrderByDescending(v => v.Value)
                                          .ThenBy(k => k.Key))
        {
            Console.WriteLine($"{participant.Key} | {participant.Value}");
        }

        Console.WriteLine("Submissions:");

        foreach (var language in submissions.OrderByDescending(v => v.Value)
                                            .ThenBy(k => k.Key))
        {
            Console.WriteLine($"{language.Key} - {language.Value}");
        }
    }
}