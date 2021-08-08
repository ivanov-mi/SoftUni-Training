namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }
        public virtual double FuelConsumption
            => DefaultFuelConsumption;
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive (double kilometeres)
        {
            bool canDrive = this.Fuel - this.FuelConsumption * kilometeres >= 0;
            
            if (canDrive)
            {
                this.Fuel -= this.FuelConsumption * kilometeres;
            }
        }
    }
}
