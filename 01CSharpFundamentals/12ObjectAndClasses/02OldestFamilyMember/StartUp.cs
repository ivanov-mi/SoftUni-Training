using System;

public class StartUp
{
    static void Main()
    {
        int numberOfPeople = int.Parse(Console.ReadLine());
        Family wholeFamily = new Family();

        for (int i = 0; i < numberOfPeople; i++)
        {
            string[] inputLine = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Person familyMember = new Person(inputLine[0], int.Parse(inputLine[1]));

            wholeFamily.AddMember(familyMember);    
        }

        Person oldestPerson = wholeFamily.GetOldestMember();

        Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
    }
}