using System;
using System.Collections.Generic;

namespace Animals
{
    public class Engine
    {
        public void Run()
        {
            var animals = new List<Animal>();

            while (true)
            {
                try
                {
                    var command = Console.ReadLine();

                    if (command == "Beast!")
                    {
                        break;
                    }

                    var animalData = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    AddAnimal(animals, command, animalData);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static void AddAnimal(List<Animal> animals, string command, string[] animalData)
        {
            var name = animalData[0];
            var age = int.Parse(animalData[1]);
            var gender = animalData[2];

            Animal currentAnimal;
            switch (command)
            {
                case "Dog":
                    currentAnimal = new Dog(name, age, gender);
                    break;
                case "Cat":
                    currentAnimal = new Cat(name, age, gender);
                    break;
                case "Frog":
                    currentAnimal = new Frog(name, age, gender);
                    break;
                case "Kitten":
                    currentAnimal = new Kitten(name, age);
                    break;
                default:
                    currentAnimal = new Tomcat(name, age);
                    break;
            }
            animals.Add(currentAnimal);
        }
    }
}
