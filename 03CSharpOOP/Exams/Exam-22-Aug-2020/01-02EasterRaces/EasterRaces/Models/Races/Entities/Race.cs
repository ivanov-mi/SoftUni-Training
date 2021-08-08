namespace EasterRaces.Models.Races.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EasterRaces.Models.Drivers.Contracts;
    using EasterRaces.Models.Races.Contracts;
    using EasterRaces.Utilities.Messages;

    public class Race : IRace
    {
        private const int MinNameLength = 5;
        private const int MinNumberOfLaps = 1;
        private string name;
        private int laps;
        private readonly List<IDriver> drivers;

        public Race(string name, int laps)
        {
            this.drivers = new List<IDriver>();
            this.Name = name;
            this.Laps = laps;
        }

        public IReadOnlyCollection<IDriver> Drivers 
            => this.drivers;

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
        public int Laps 
        { 
            get => this.laps;

            private set
            {
                if (value < MinNumberOfLaps)
                {
                    throw new ArgumentException(string.Format(
                        ExceptionMessages.InvalidNumberOfLaps,
                        MinNumberOfLaps));
                }

                this.laps = value;
            }
        }

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(nameof(IDriver), string.Format(
                    ExceptionMessages.DriverInvalid));
            }

            if (driver.CanParticipate == false)
            {
                throw new ArgumentException(string.Format(
                    ExceptionMessages.DriverNotParticipate,
                    driver.Name));
            }

            if (drivers.Any(x => x.Name == driver.Name))
            {
                throw new ArgumentNullException(nameof(IDriver), string.Format(
                     ExceptionMessages.DriverAlreadyAdded,
                     driver.Name,
                     this.Name));
            }

            drivers.Add(driver);
        }
    }
}
