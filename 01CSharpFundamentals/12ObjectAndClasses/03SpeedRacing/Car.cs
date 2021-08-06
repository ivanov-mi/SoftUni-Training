using System;

public class Car
{
    public Car(string model, double fuelAmount, double fuelConsumptionsPerKM)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumptionsPerKM = fuelConsumptionsPerKM;
        this.DistanceTraveled = 0;
    }

    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsumptionsPerKM { get; set; }
    public int DistanceTraveled { get; set; }

    public void drivingCar(int driveDistance)
    {
        if (FuelAmount < FuelConsumptionsPerKM * driveDistance )
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
        else
        {
            DistanceTraveled += driveDistance;
            FuelAmount -= FuelConsumptionsPerKM * driveDistance;
        }
    }
}