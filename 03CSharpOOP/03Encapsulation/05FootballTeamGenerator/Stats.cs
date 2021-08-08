using System;

namespace FootballTeamGenerator
{
    public class Stats
    {
        private const int MinStat = 0;
        private const int MaxStat = 100;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shoooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shoooting;
        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                this.ValidateSkill(value, nameof(this.Endurance));
                this.endurance = value;
            }
        }
        public int Sprint
        {
            get => this.sprint;
            private set
            {
                this.ValidateSkill(value, nameof(this.Sprint));
                this.sprint = value;
            }
        }

        public int Dribble
        {
            get => this.dribble;
            private set
            {
                this.ValidateSkill(value, nameof(this.Dribble));
                this.dribble = value;
            }
        }

        public int Passing
        {
            get => this.passing;
            private set
            {
                this.ValidateSkill(value, nameof(this.Passing));
                this.passing = value;
            }
        }

        public int Shooting
        {
            get => this.shooting;
            private set
            {
                this.ValidateSkill(value, nameof(this.Shooting));
                this.shooting = value;
            }
        }
        
        public double GetPlayerStats
           => (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0;

        private void ValidateSkill(int value, string skillName)
        {
            if (value < MinStat || value > MaxStat)
            {
                throw new ArgumentException($"{skillName} should be between {MinStat} and {MaxStat}.");
            }
        }
    }
}
