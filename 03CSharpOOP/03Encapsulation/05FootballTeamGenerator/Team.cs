using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> team;

        public Team(string name)
        {
            this.Name = name;
            this.team = new List<Player>();
        }

        public string Name 
        { 
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public int TeamRating()
        {
            if (this.team.Count == 0)
            {
                return 0;
            }

            return (int)Math.Round(this.team.Average(x => x.PlayerSkillLevel), 0);
        }

        public void AddPlayer(Player player)
        {
            this.team.Add(player);
        }

        public void RemovePlayer(string name)
        {
            var playerToRemove = this.team.FirstOrDefault(x => x.Name == name);

            if (playerToRemove != null)
            {
                this.team.Remove(playerToRemove);
            }
            else
            {
                Console.WriteLine($"Player {name} is not in {this.Name} team.");
            }
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TeamRating()}";
        }
    }
}
