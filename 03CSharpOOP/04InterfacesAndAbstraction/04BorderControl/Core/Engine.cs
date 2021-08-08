namespace BorderControl.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models;

    public class Engine
    {
        private List<IIdentifiable> inhabitants;

        public Engine()
        {
            this.inhabitants = new List<IIdentifiable>();
        }

        public void Run()
        {
            IIdentifiable inhabitant = null;
            
            var input = Console.ReadLine();

            while (input != "End")
            {
                var inputData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (inputData.Length == 2)
                {
                    inhabitant = CreateRobot(inputData);
                }
                else if (inputData.Length == 3)
                {
                    inhabitant = CreateCitizen(inputData);
                }

                inhabitants.Add(inhabitant);              

                input = Console.ReadLine();
            }

            var fakeIdsLastDigits = Console.ReadLine();
            var inhabitansToBeDetained = inhabitants.Where(x => x.CheckId(fakeIdsLastDigits));

            foreach (var id in inhabitansToBeDetained)
            {
                Console.WriteLine(id.Id);
            }
        }

        private static IIdentifiable CreateRobot(string[] inputData)
        {
            IIdentifiable inhabitant;
            var model = inputData[0];
            var id = inputData[1];
            inhabitant = new Robot(model, id);
            return inhabitant;
        }

        private static IIdentifiable CreateCitizen(string[] inputData)
        {
            IIdentifiable inhabitant;
            var name = inputData[0];
            var age = int.Parse(inputData[1]);
            var id = inputData[2];
            inhabitant = new Citizen(name, age, id);
            return inhabitant;
        }
    }
}
