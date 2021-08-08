namespace WildFarm.Core
{
    using System;
    using System.Collections.Generic;
    using Factories;
    using Contracts;

    public class Engine
    {
        private List<IAnimal> animals;

        public Engine()
        {
            this.animals = new List<IAnimal>();
        }

        public void Run()
        {
            var animalFactory = new AnimalFactory();
            var foodFactory = new FoodFactory();
            var input = string.Empty;

            while ((input = Console.ReadLine())?.ToLower() != "end")
            {
                var inputAnimal = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var inputFood = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    var animal = animalFactory.CreateAnimal(inputAnimal);
                    animals.Add(animal);
                    Console.WriteLine(animal.ProduceSound());

                    var food = foodFactory.CreateFood(inputFood);
                    animal.FeedAnimal(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
