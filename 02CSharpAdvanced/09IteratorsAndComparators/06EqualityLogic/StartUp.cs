using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    class StartUp
    {
        static void Main()
        {
            var sortedSetOfPeople = new SortedSet<Person>();
            var hashSetOfPeople = new HashSet<Person>();

            var numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                var inputData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var name = inputData[0];
                var age = int.Parse(inputData[1]);

                var person = new Person(name, age);

                sortedSetOfPeople.Add(person);
                hashSetOfPeople.Add(person);
            }

            Console.WriteLine($"{sortedSetOfPeople.Count}");
            Console.WriteLine($"{hashSetOfPeople.Count}");
        }
    }
}