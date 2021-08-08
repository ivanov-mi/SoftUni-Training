namespace FoodShortage.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models;

    public class Engine
    {
        private Dictionary<string, IBuyer> people;

        public Engine()
        {
            this.people = new Dictionary<string, IBuyer>();
        }

        public void Run()
        {
            InputPeople();

            BuyFood();

            OutputBuyedFood();
        }

        private void OutputBuyedFood()
        {
            var totalFoodBuyed = people.Select(x => x.Value).Sum(x => x.Food);
            Console.WriteLine(totalFoodBuyed);
        }

        private void BuyFood()
        {
            var buyer = Console.ReadLine();

            while (buyer != "End")
            {
                if (people.ContainsKey(buyer))
                {
                    people[buyer].BuyFood();
                }

                buyer = Console.ReadLine();
            }
        }

        private void InputPeople()
        {
            var numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                var personData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var name = personData[0];
                var age = int.Parse(personData[1]);

                IBuyer person = null;

                switch (personData.Length)
                {
                    case 3:
                        var group = personData[2];
                        person = new Rebel(name, age, group);
                        break;
                    case 4:
                        var id = personData[2];
                        var birthdate = personData[3];
                        person = new Citizen(name, age, id, birthdate);
                        break;
                    default:
                        break;
                }
                people.Add(name, person);
            }
        }
    }
}
