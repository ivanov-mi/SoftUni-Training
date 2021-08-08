namespace VehiclesExtension.Contracts
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }

        public double FuelConsumption { get; }

        public double TankCapacity { get; }

        public void Drive(double distance);

        public void Refuel(double fuel);
    }
}
