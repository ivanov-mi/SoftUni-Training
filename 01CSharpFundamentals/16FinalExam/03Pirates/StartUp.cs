using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        List<City> citiesList = new List<City>();
        string inputCities;

        while ((inputCities = Console.ReadLine())?.ToLower() != "sail")
        {
            AddOrEditCity(citiesList, inputCities);
        }

        string events;

        while ((events = Console.ReadLine())?.ToLower() != "end")
        {
            string[] str = events
                .Split("=>", StringSplitOptions.RemoveEmptyEntries);
            string action = str[0];

            switch (action.ToLower())
            {
                case "plunder":
                    Plunder(citiesList, str);
                    break;

                case "prosper":
                    Prosper(citiesList, str);
                    break;
            }
        }      

        Console.WriteLine($"Ahoy, Captain! There are {citiesList.Count} wealthy settlements to go to:");

        if (citiesList.Count > 0)
        {
            foreach (var town in citiesList.OrderByDescending(x => x.Gold).ThenBy(x => x.Name))
            {
                Console.WriteLine($"{town.Name} -> Population: {town.Population} citizens, Gold: {town.Gold} kg");
            }
        }
        else
        {
            Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
        }
    }

    private static void AddOrEditCity(List<City> citiesList, string inputCities)
    {
        string[] str = inputCities
            .Split("||", StringSplitOptions.RemoveEmptyEntries);
        string cityName = str[0];
        int people = int.Parse(str[1]);
        int gold = int.Parse(str[2]);

        City existingCity = citiesList.Find(x => x.Name == cityName);

        if (existingCity != null)
        {
            existingCity.Population += people;
            existingCity.Gold += gold;
        }
        else
        {
            citiesList.Add(new City(cityName, people, gold));
        }
    }

    private static void Prosper(List<City> cities, string[] str)
    {
        string cityName = str[1];
        int goldToAdd = int.Parse(str[2]);
        City currentCity = cities.Find(x => x.Name == cityName);

        if (goldToAdd < 0)
        {
            Console.WriteLine("Gold added cannot be a negative number!");
        }
        else
        {
            currentCity.Gold += goldToAdd;

            Console.WriteLine($"{goldToAdd} gold added to the city treasury. {currentCity.Name} now has {currentCity.Gold} gold.");
        }
    }

    private static void Plunder(List<City> cities, string[] str)
    {
        string cityName = str[1];
        int people = int.Parse(str[2]);
        int gold = int.Parse(str[3]);
        City currentCity = cities.Find(x => x.Name == cityName);

        Console.WriteLine($"{currentCity.Name} plundered! {gold} gold stolen, {people} citizens killed.");

        currentCity.Population -= people;
        currentCity.Gold -= gold;

        if (currentCity.Population <= 0 || currentCity.Gold <= 0)
        {
            Console.WriteLine($"{currentCity.Name} has been wiped off the map!");

            cities.Remove(currentCity);
        }
    }
}