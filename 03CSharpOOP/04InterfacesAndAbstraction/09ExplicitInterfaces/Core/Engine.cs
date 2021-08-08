namespace ExplicitInterfaces.Core
{
    using System;
    using Contracts;
    using Models;

    public class Engine
    {
        public void Run()
        {
            var input = Console.ReadLine();

            while (input != "End")
            {
                var personInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var name = personInfo[0];
                var country = personInfo[1];
                var age = int.Parse(personInfo[2]);

                Citizen citizen = new Citizen(name, country, age);

                IPerson person = citizen;
                IResident resident = citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());

                input = Console.ReadLine();
            }
        }
    }
}
