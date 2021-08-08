namespace Vehicles.Core
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Models;

    public class Engine
    {
        private Dictionary<string, IVehicle> vehicles;
        private const int numberOfVehicles = 2;

        public Engine()
        {
            this.vehicles = new Dictionary<string, IVehicle>();
        }

        public void Run()
        {
            InputVehicles();

            DriveVehicles();

            PrintVehicles();
        }

        private void InputVehicles()
        {
            for (int i = 0; i < numberOfVehicles; i++)
            {
                var inputData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var typeOfVehicle = inputData[0];
                var fuel = double.Parse(inputData[1], System.Globalization.CultureInfo.InvariantCulture);
                var consumption = double.Parse(inputData[2], System.Globalization.CultureInfo.InvariantCulture);

                Vehicle vehicle = null;

                switch (typeOfVehicle?.ToLower())
                {
                    case "car":
                        vehicle = new Car(fuel, consumption);
                        break;
                    case "truck":
                        vehicle = new Truck(fuel, consumption);
                        break;
                }

                vehicles.Add(typeOfVehicle, vehicle);
            }
        }

        private void DriveVehicles()
        {
            var numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                var commandInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = commandInfo[0];
                var vehicle = commandInfo[1];
                var parameter = double.Parse(commandInfo[2], System.Globalization.CultureInfo.InvariantCulture);

                if (vehicles.ContainsKey(vehicle))
                {
                    switch (command?.ToLower())
                    {
                        case "drive":
                            vehicles[vehicle].Drive(parameter);
                            break;
                        case "refuel":
                            vehicles[vehicle].Refuel(parameter);
                            break;
                    }
                }
            }
        }

        private void PrintVehicles()
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"{vehicle.Key}: {vehicle.Value.FuelQuantity:F2}");
            }
        }
    }
}
