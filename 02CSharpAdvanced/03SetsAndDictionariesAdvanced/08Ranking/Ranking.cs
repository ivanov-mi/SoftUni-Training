using System;
using System.Collections.Generic;
using System.Linq;

class Ranking
{
    static void Main()
    {
        var contests = new Dictionary<string, string>();

        InputContests(contests);

        var results = new Dictionary<string, Dictionary<string, int>>();

        InputCandidates(contests, results);

        var bestCandidate = results.OrderByDescending(x => x.Value.Values.Sum())
                                   .FirstOrDefault();

        Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Values.Sum()} points.");

        Console.WriteLine("Ranking: ");
        foreach (var username in results.OrderBy(x => x.Key))
        {
            Console.WriteLine(username.Key);
            foreach (var result in username.Value.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"#  {result.Key} -> {result.Value}");
            }
        }
    }

    private static void InputCandidates(Dictionary<string, string> contests, Dictionary<string, Dictionary<string, int>> results)
    {
        string contestResultsInput = string.Empty;

        while ((contestResultsInput = Console.ReadLine()) != "end of submissions")
        {
            string[] inputStringArray = contestResultsInput.Split(new char[] { ':', '=', '>' }, StringSplitOptions.RemoveEmptyEntries);
            string contest = inputStringArray[0];
            string password = inputStringArray[1];
            string username = inputStringArray[2];
            int points = int.Parse(inputStringArray[3]);

            if (contests.ContainsKey(contest) && contests[contest] == password)
            {
                if (results.ContainsKey(username) == false)
                {
                    results.Add(username, new Dictionary<string, int>
                                                {
                                                    { contest, points }
                                                });
                }
                else
                {
                    if (results[username].ContainsKey(contest) == false)
                    {
                        results[username].Add(contest, points);
                    }
                    else if (results[username].ContainsKey(contest) && results[username][contest] < points)
                    {
                        results[username][contest] = points;
                    }
                }
            }

        }
    }

    private static void InputContests(Dictionary<string, string> contests)
    {
        string contestsInput = string.Empty;

        while ((contestsInput = Console.ReadLine()).ToLower() != "end of contests")
        {
            string[] inputStringArray = contestsInput.Split(':', StringSplitOptions.RemoveEmptyEntries);
            string contest = inputStringArray[0];
            string password = inputStringArray[1];

            contests.Add(contest, password);
        }
    }
}

