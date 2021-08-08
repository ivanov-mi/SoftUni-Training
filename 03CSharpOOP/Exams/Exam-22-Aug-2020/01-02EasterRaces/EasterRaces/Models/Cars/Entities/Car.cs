namespace EasterRaces.Models.Cars.Entities
{
    using System;
    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Utilities.Messages;

    public abstract class Car : ICar
    {
        private const int MinNameLength = 4;

        private string model;
        private int horsePower;
        private readonly int minHorsePower;
        private readonly int maxHorsePower;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;

            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model 
        { 
            get => this.model;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MinNameLength)
                {
                    throw new ArgumentException(string.Format(
                        ExceptionMessages.InvalidModel,
                        value,
                        MinNameLength));
                }

                this.model = value;
            }
        }

        public int HorsePower 
        { 
            get => this.horsePower;
            private set
            {
                if (value > this.maxHorsePower || value < this.minHorsePower)
                {
                    throw new ArgumentException(string.Format(
                        ExceptionMessages.InvalidHorsePower,
                        value));
                }

                this.horsePower = value;
            }
        }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps) => (double) this.CubicCentimeters / this.HorsePower * laps;
    }
}
