using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        int numberOfCars = int.Parse(Console.ReadLine());
        List<Car> carList = new List<Car>();

        for (int i = 0; i < numberOfCars; i++)
        {
            string[] carsInputLine = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string model = carsInputLine[0];
            double fuelAmount = double.Parse(carsInputLine[1]);
            double fuelConsumptionsPerKM = double.Parse(carsInputLine[2]);

            Car inputCar = new Car(model, fuelAmount ,fuelConsumptionsPerKM);

            carList.Add(inputCar);        
        }

        string driveInputLine = string.Empty;
       
        while ((driveInputLine = Console.ReadLine()) != "End")
        {
            string[] driveParameters = driveInputLine
                .Split(new string[] { "Drive", " " }, StringSplitOptions.RemoveEmptyEntries);
            string carModel = driveParameters[0];
            int driveDistance = int.Parse(driveParameters[1]);

            Car currentCar = carList
                .Where(x => x.Model == carModel)
                .FirstOrDefault();

            currentCar.drivingCar(driveDistance);      
        }

        foreach (var car in carList)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceTraveled}");
        }
    }
}