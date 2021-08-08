namespace EasterRaces.Models.Drivers.Entities
{
    using System;
    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Models.Drivers.Contracts;
    using EasterRaces.Utilities.Messages;

    public class Driver : IDriver
    {
        private const int MinNameLength = 5;
        private string name;

        public Driver(string name)
        {
            this.Name = name;
            this.NumberOfWins = 0;
        }
        public string Name 
        { 
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MinNameLength)
                {
                    throw new ArgumentException(string.Format(
                        ExceptionMessages.InvalidName,
                        value,
                        MinNameLength));
                }

                this.name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate
            => this.Car != null;

        public void AddCar(ICar car)
        {
            this.Car = car ?? throw new ArgumentNullException(nameof(ICar), string.Format(
                    ExceptionMessages.CarInvalid));
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
