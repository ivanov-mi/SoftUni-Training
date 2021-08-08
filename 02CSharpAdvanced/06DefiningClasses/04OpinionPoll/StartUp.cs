using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            var numberOfPeople = int.Parse(Console.ReadLine());

            var people = new List<Person>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                var inputLine = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var name = inputLine[0];
                var age = int.Parse(inputLine[1]);

                var currentPerson = new Person(name, age);

                people.Add(currentPerson);
            }

            var result = people
                .Where(a => a.Age > 30)
                .OrderBy(n => n.Name);

            foreach (var person in result)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
