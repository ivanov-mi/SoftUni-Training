using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, int>> players = new Dictionary<string, Dictionary<string, int>>();

        string inputLine = string.Empty;

        while ((inputLine = Console.ReadLine()).ToLower() != "season end")
        {
            string[] inputStringArray = inputLine.Split(new string[] {" -> ", ">", "-", " vs ", " " },
                    StringSplitOptions.RemoveEmptyEntries);

            switch (inputStringArray.Length)
            {
                case 2:
                    Duel(players, inputStringArray);
                        break;
                case 3:
                    AddPlayer(players, inputStringArray);
                    break;
                default:
                    break;
            }
        }

        foreach (var player in players.OrderByDescending(x => x.Value.Sum(x => x.Value))
                                      .ThenBy(x => x.Key))
        {
            Console.WriteLine($"{player.Key}: {player.Value.Sum(x => x.Value)} skill");

            foreach (var position in player.Value.OrderByDescending(x => x.Value)
                                                 .ThenBy(x => x.Key))
            {
                Console.WriteLine($"- {position.Key} <::> {position.Value}");
            
            }
        }
    }

    static void Duel(Dictionary<string, Dictionary<string, int>> players, string[] inputStringArray)
    {
        string firstPlayer = inputStringArray[0];
        string secondPlayer = inputStringArray[1];

        if (players.ContainsKey(firstPlayer) && players.ContainsKey(secondPlayer) &&
                players[firstPlayer].Keys.Intersect(players[secondPlayer].Keys).Any())
        {
            int firstPlayerTotalPoints = players[firstPlayer].Sum(x => x.Value);
            int secondPlayerTotalPoints = players[secondPlayer].Sum(x => x.Value);

            if (firstPlayerTotalPoints > secondPlayerTotalPoints)
            {
                players.Remove(secondPlayer);
            }
            else if (firstPlayerTotalPoints < secondPlayerTotalPoints)
            {
                players.Remove(firstPlayer);
            }
        }
    }

    static void AddPlayer(Dictionary<string, Dictionary<string, int>> players, string[] inputStringArray)
    {
        string playerName = inputStringArray[0];
        string position = inputStringArray[1];
        int skill = int.Parse(inputStringArray[2]);

        if (players.ContainsKey(playerName) == false)
        {
            players.Add(playerName, new Dictionary<string, int>
            {
                { position, skill }
            });
        }
        else if (players[playerName].ContainsKey(position) == false)
        {
            players[playerName].Add(position, skill);
        }
        else if (players[playerName][position] < skill)
        {
            players[playerName][position] = skill;
        }
    }
}