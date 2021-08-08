using System;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private Stats playerStats;

        public Player(string name, Stats playerStats)
        {
            this.Name = name;
            this.playerStats = playerStats;
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

                name = value;
            }
        }

        public double PlayerSkillLevel
          => this.playerStats.GetPlayerStats;
    }
}
