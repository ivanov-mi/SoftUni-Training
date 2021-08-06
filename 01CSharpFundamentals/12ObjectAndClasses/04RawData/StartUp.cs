using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        int numberOfCars = int.Parse(Console.ReadLine());
        List<Model> listOfCars = new List<Model>();

        for (int i = 0; i < numberOfCars; i++)
        {
            string[] inputLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string model = inputLine[0];
            int engineSpeed = int.Parse(inputLine[1]);
            int enginePower = int.Parse(inputLine[2]);
            int cargoWeight = int.Parse(inputLine[3]);
            string cargoType = inputLine[4];

            Engine engineProperties = new Engine(engineSpeed, enginePower);
            Cargo cargoSpecifications = new Cargo(cargoWeight, cargoType);
            Model currentCar = new Model(model, engineProperties, cargoSpecifications);

            listOfCars.Add(currentCar);
        }

        string inputCommand = Console.ReadLine();
        List<string> selectedCard = new List<string>();

        if (inputCommand == "fragile")
        {
            selectedCard = listOfCars
                .Where(x => x.CargoSpecifications.CargoType == "fragile" && x.CargoSpecifications.CargoWeight < 1000)
                .Select(x => x.ModelOfCar)
                .ToList();
        }
        else
        {
            selectedCard = listOfCars
                .Where(x => x.CargoSpecifications.CargoType == "flamable" && x.EngineProperties.EnginePower > 250)
                .Select(x => x.ModelOfCar)
                .ToList();
        }

        foreach (var car in selectedCard)
        {
            Console.WriteLine(car);
        }
    }
}