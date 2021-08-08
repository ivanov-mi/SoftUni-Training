using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace _06.SpeedRacing
{
    class Program
    {
        static void Main()
        {
            var numberOfCars = int.Parse(Console.ReadLine());
            var cars = new List<Car>(numberOfCars);

            for (int i = 0; i < numberOfCars; i++)
            {
                var carsInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var model = carsInput[0];
                var fuelAmount = double.Parse(carsInput[1]);
                var fuelConsumptionFor1km = double.Parse(carsInput[2] /*, CultureInfo.InvariantCulture*/);

                cars.Add(new Car(model, fuelAmount, fuelConsumptionFor1km));
            }

            string commandLine;

            while ((commandLine = Console.ReadLine())?.ToLower() != "end")
            {
                var commands = commandLine
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var carModel = commands[1];
                var amountofKm = int.Parse(commands[2]);

                var currentCar = cars.Where(x => x.Model == carModel).FirstOrDefault();

                currentCar.Drive(amountofKm);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}
