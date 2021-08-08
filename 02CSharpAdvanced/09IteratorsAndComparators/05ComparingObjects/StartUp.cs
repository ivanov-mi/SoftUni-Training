using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    class StartUp
    {
        static void Main()
        {
            var people = new List<Person>();
            var inputData = Console.ReadLine();

            while (inputData?.ToLower() != "end")
            {
                var personData = inputData.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var name = personData[0];
                var age = int.Parse(personData[1]);
                var town = personData[2];

                people.Add(new Person(name, age, town));

                inputData = Console.ReadLine();
            }

            var personToCheckPosition = int.Parse(Console.ReadLine());

            var personToCheck = people[personToCheckPosition - 1];
            var countOfMatches = 0;

            foreach (var person in people)
            {
                if (personToCheck.CompareTo(person) == 0)
                {
                    countOfMatches++;
                }
            }

            if (countOfMatches == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{countOfMatches} {people.Count - countOfMatches} {people.Count}");
            }
        }
    }
}