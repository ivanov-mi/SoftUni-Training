namespace VehiclesExtension.Models
{
    using System;

    public class Bus : Vehicle
    {
        private const double increaseOfFuelConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += increaseOfFuelConsumption;
        }

        public void DriveEmpty(double distance)
        {
            this.FuelConsumption -= increaseOfFuelConsumption;
            base.Drive(distance);
        }
    }
}
