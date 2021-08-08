namespace VehiclesExtension.Models
{
    using System;
    using Contracts;

    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelConsumption = fuelConsumption;
            this.FuelQuantity = fuelQuantity;
        }

        public double TankCapacity { get; private set; }

        public double FuelConsumption { get; protected set; }

        public double FuelQuantity 
        { 
            get => this.fuelQuantity;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    value = 0;
                }

                this.fuelQuantity = value;
            }
        }

        public void Drive(double distance)
        {
            var range = this.FuelQuantity / this.FuelConsumption;

            if (range < distance)
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
            else
            {
                this.FuelQuantity -= distance * this.FuelConsumption;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }
            else if (fuel + this.FuelQuantity > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {fuel} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += fuel;
            }
        }
    }
}
