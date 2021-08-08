using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Engine
    {
        private List<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            var inputLine = Console.ReadLine();

            while (inputLine?.ToLower() != "end")
            {
                try
                {
                    var commands = inputLine.Split(';');

                    var command = commands[0];
                    var teamName = commands[1];

                    switch (command.ToLower())
                    {
                        case "team":
                            CreateTeam(this.teams, teamName);
                            break;
                        case "add":
                            AddPlayer(this.teams, commands, teamName);
                            break;
                        case "remove":
                            RemovePlayer(this.teams, commands, teamName);
                            break;
                        case "rating":
                            PrintTeamRating(this.teams, teamName);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                inputLine = Console.ReadLine();
            }
        }

        private static void CreateTeam(List<Team> teams, string teamName)
        {
            var team = new Team(teamName);
            teams.Add(team);
        }

        private static void AddPlayer(List<Team> teams, string[] commands, string teamName)
        {
            var currentTeam = teams.FirstOrDefault(x => x.Name == teamName);
            ValidateTeamName(currentTeam, teamName);

            Player newPlayer = CreatePlayer(commands);

            currentTeam.AddPlayer(newPlayer);
        }

        private static Player CreatePlayer(string[] commands)
        {
            var playerName = commands[2];
            var endurance = int.Parse(commands[3]);
            var sprint = int.Parse(commands[4]);
            var dribble = int.Parse(commands[5]);
            var passing = int.Parse(commands[6]);
            var shooting = int.Parse(commands[7]);

            var playerStats = new Stats(endurance, sprint, dribble, passing, shooting);
            var newPlayer = new Player(playerName, playerStats);

            return newPlayer;
        }

        private static void RemovePlayer(List<Team> teams, string[] commands, string teamName)
        {
            var currentTeam = teams.FirstOrDefault(x => x.Name == teamName);
            ValidateTeamName(currentTeam, teamName);

            var playerName = commands[2];
            currentTeam.RemovePlayer(playerName);
        }

        private static void PrintTeamRating(List<Team> teams, string teamName)
        {
            var currentTeam = teams.FirstOrDefault(x => x.Name == teamName);
            ValidateTeamName(currentTeam, teamName);

            Console.WriteLine(currentTeam);
        }

        private static void ValidateTeamName(Team currentTeam, string teamName)
        {
            if (currentTeam == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }
        }
    }
}
