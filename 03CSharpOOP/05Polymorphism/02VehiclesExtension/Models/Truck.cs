namespace VehiclesExtension.Models
{
    using System;

    public class Truck : Vehicle
    {
        private const double increaseOfFuelConsumption = 1.6;
        private const double fuelLost = 0.05;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += increaseOfFuelConsumption;
        }

        public override void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (fuel + this.FuelQuantity > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += fuel * (1 - fuelLost);
            }
        }
    }
}
