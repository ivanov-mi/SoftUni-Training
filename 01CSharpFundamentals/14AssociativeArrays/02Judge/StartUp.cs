using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, int>> individualStatistics = new Dictionary<string, Dictionary<string, int>>();

        InputIndividualStatistics(individualStatistics);

        Dictionary<string, int> ranking = individualStatistics
            .SelectMany(x => x.Value)
            .GroupBy(x => x.Key)
            .Select(x => new
            {
                x.Key,
                Points = x.Sum(x => x.Value)
            })
            .OrderByDescending(x => x.Points)
            .ThenBy(x => x.Key)
            .ToDictionary(x => x.Key, x => x.Points);

        //Print contest statistics
        foreach (var contests in individualStatistics)
        {
            Console.WriteLine($"{contests.Key}: {contests.Value.Count} participants");
            int position = 1;

            foreach (var participant in contests.Value
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{position}. {participant.Key} <::> {participant.Value}");
                position++;
            }
        }

        //Print individual rankinkg
        Console.WriteLine("Individual standings:");
        int individualRanking = 1;

        foreach (var participant in ranking)
        {
            Console.WriteLine($"{individualRanking}. {participant.Key} -> {participant.Value}");
            individualRanking++;
        }
    }

    static void InputIndividualStatistics(Dictionary<string, Dictionary<string, int>> individualStatistics)
    {
        string inputLine = string.Empty;

        while ((inputLine = Console.ReadLine()).ToLower() != "no more time")
        {
            string[] inputStringArray = inputLine.Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
            string username = inputStringArray[0];
            string contest = inputStringArray[1];
            int points = int.Parse(inputStringArray[2]);

            if (individualStatistics.ContainsKey(contest) == false)
            {
                individualStatistics.Add(contest, new Dictionary<string, int>
                {
                    {username, points}
                });
            }
            else if (individualStatistics[contest].ContainsKey(username) == false)
            {
                individualStatistics[contest].Add(username, points);
            }
            else if (individualStatistics[contest].ContainsKey(username) && individualStatistics[contest][username] < points)
            {
                individualStatistics[contest][username] = points;
            }
        }
    }
}