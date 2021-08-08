using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            var family = new Family();
            var numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                var inputLine = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var name = inputLine[0];
                var age = int.Parse(inputLine[1]);

                var currentPerson = new Person(name, age);

                family.AddMember(currentPerson);
            }

            var oldestPerson = family.GetOldestMember();

            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
