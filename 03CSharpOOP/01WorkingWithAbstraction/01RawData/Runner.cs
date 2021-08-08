using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class Runner
    {
        public void Run()
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                GenerateCar(cars, parameters);
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();
                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {

                List<string> flamable = cars
                .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                .Select(x => x.Model)
                .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }

        private static void GenerateCar(List<Car> cars, string[] parameters)
        {
            string model = parameters[0];

            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            var engine = new Engine(engineSpeed, enginePower);

            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];
            var cargo = new Cargo(cargoWeight, cargoType);

            var tires = new Tire[4];
            double firstTirePressure = double.Parse(parameters[5]);
            int firstTireAge = int.Parse(parameters[6]);
            tires[0] = new Tire(firstTireAge, firstTirePressure);

            double secondTirePressure = double.Parse(parameters[7]);
            int secondTireAge = int.Parse(parameters[8]);
            tires[1] = new Tire(secondTireAge, secondTirePressure);

            double thirdTirePressure = double.Parse(parameters[9]);
            int thirdTireAge = int.Parse(parameters[10]);
            tires[2] = new Tire(thirdTireAge, thirdTirePressure);

            double forthTirePressure = double.Parse(parameters[11]);
            int forthTireAge = int.Parse(parameters[12]);
            tires[3] = new Tire(forthTireAge, forthTirePressure);

            cars.Add(new Car(model, engine, cargo, tires));
        }
    }
}
