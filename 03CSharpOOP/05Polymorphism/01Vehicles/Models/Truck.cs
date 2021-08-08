namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double increaseOfFuelConsumption = 1.6;
        private const double fuelLost = 0.05;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += increaseOfFuelConsumption;
        }

        public override void Refuel(double fuel)
        {
            this.FuelQuantity += fuel * (1 - fuelLost);
        }
    }
}
