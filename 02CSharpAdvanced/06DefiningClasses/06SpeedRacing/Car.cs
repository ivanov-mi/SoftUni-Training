using System;
namespace _06.SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsuptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsuptionPerKilometer = fuelConsuptionPerKilometer;
            this.TravelledDistance = 0;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsuptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void Drive(double amountOfKm)
        {
            if (amountOfKm * this.FuelConsuptionPerKilometer > this.FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                this.TravelledDistance += amountOfKm;
                this.FuelAmount -= amountOfKm * this.FuelConsuptionPerKilometer;
            }
        }
    }
}
