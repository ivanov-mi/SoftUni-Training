using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _07.RawDAta
{
    class Program
    {
        static void Main()
        {
            var numberOfCars = int.Parse(Console.ReadLine());
            var cars = new List<Car>(numberOfCars);

            for (int i = 0; i < numberOfCars; i++)
            {
                var dataInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var model = dataInput[0];

                var engineSpeed = int.Parse(dataInput[1]);
                var enginePower = int.Parse(dataInput[2]);
                var engineData = new Engine(engineSpeed, enginePower);

                var cargoWeight = int.Parse(dataInput[3]);
                var cargoType = dataInput[4];
                var cargoData = new Cargo(cargoWeight, cargoType);

                var tires = new Tire[4];
                var counter = 0;

                for (int j = 5; j < dataInput.Length; j += 2)
                {
                    var tyrePressure = double.Parse(dataInput[j], CultureInfo.InvariantCulture);
                    var tyreAge = int.Parse(dataInput[j + 1]);

                    tires[counter] = new Tire(tyrePressure, tyreAge);

                    counter++;
                }

                var currentCar = new Car(model, engineData, cargoData, tires);

                cars.Add(currentCar);
            }

            var result = new List<Car>();
            
            var command = Console.ReadLine();

            if (command?.ToLower() == "fragile")
            {
                result = cars.Where(x => x.Tire.Any(y => y.TirePressure < 1))
                    .ToList();
            }
            else if (command?.ToLower() == "flamable")
            {
                result = cars.Where(x => x.Engine.EnginePower > 250)
                    .ToList();
            }

            foreach (var car in result)
            {
                Console.WriteLine(car.ModelName);
            }
        }
    }
}
