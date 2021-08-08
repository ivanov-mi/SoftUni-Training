namespace BirthdayCelebrations.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models;

    public class Engine
    {
        private List<IBirthdatable> mammals;

        public Engine()
        {
            this.mammals = new List<IBirthdatable>();
        }

        public void Run()
        {
            IBirthdatable mammal = null;

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                var inputData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = inputData[0];

                if (command == "Robot")
                {
                    continue;
                }
                else if (command == "Citizen")
                {
                    mammal = CreateCitizen(inputData);
                }
                else if (command == "Pet")
                {
                    mammal = CreatePet(inputData);
                }

                mammals.Add(mammal);              
            }

            var birthdateYear = Console.ReadLine();
            var birthdates = mammals.Where(x => x.Birthdate.EndsWith(birthdateYear));

            foreach (var birthdate in birthdates)
            {
                Console.WriteLine(birthdate.Birthdate);
            }
        }

        private static IBirthdatable CreateCitizen(string[] inputData)
        {
            var name = inputData[1];
            var age = int.Parse(inputData[2]);
            var id = inputData[3];
            var birthdate = inputData[4];
            return new Citizen(name, age, id, birthdate);
        }

        private IBirthdatable CreatePet(string[] inputData)
        {
            var name = inputData[1];
            var birthdate = inputData[2];
            return new Pet(name, birthdate);
        }
    }
}
