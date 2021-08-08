using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CarSalesman
{
    class Program
    {
        static void Main()
        {
            var numberOfEngines = int.Parse(Console.ReadLine());
            var engines = new List<Engine>(numberOfEngines);

            for (int i = 0; i < numberOfEngines; i++)
            {
                var engineInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var engineModel = engineInput[0];
                var power = int.Parse(engineInput[1]);
                int displacement;
                string efficiency;

                switch (engineInput.Length)
                {
                    case 2:
                        engines.Add(new Engine(engineModel, power));
                        break;
                    case 3:
                        bool isNumber = int.TryParse(engineInput[2], out displacement);

                        if (isNumber)
                        {
                            engines.Add(new Engine(engineModel, power, displacement));
                        }
                        else
                        {
                            efficiency = engineInput[2];
                            engines.Add(new Engine(engineModel, power, efficiency));
                        }
                        break;
                    case 4:
                        displacement = int.Parse(engineInput[2]);
                        efficiency = engineInput[3];
                        engines.Add(new Engine(engineModel, power, displacement, efficiency));
                        break;
                    default:
                        break;
                }
            }

            var numberOfCars = int.Parse(Console.ReadLine());
            var cars = new List<Car>(numberOfCars);

            for (int i = 0; i < numberOfCars; i++)
            {
                var inputCar = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var carModel = inputCar[0];
                var currentEngineName = inputCar[1];
                var engine = engines.Where(x => x.EngineModel == currentEngineName).FirstOrDefault();
                int weight;
                string color;

                switch (inputCar.Length)
                {
                    case 2:
                        cars.Add(new Car(carModel, engine));
                        break;
                    case 3:
                        bool isNumber = int.TryParse(inputCar[2], out weight);

                        if (isNumber)
                        {
                            cars.Add(new Car(carModel, engine, weight));
                        }
                        else
                        {
                            color = inputCar[2];
                            cars.Add(new Car(carModel, engine, color));
                        }
                        break;
                    case 4:
                        weight = int.Parse(inputCar[2]);
                        color = inputCar[3];
                        cars.Add(new Car(carModel, engine, weight, color));
                        break;
                    default:
                        break;
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
