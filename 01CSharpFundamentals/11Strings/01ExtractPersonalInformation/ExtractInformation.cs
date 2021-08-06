using System;

class ExtractInformation
{
    static void Main()
    {
        int numberOfLines = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfLines; i++)
        {
            string inputLine = Console.ReadLine();

            int nameStartIndex = inputLine.IndexOf('@') + 1;
            int nameEndIndex = inputLine.IndexOf('|');

            string name = inputLine.Substring(nameStartIndex, (nameEndIndex - nameStartIndex));

            int ageStartIndex = inputLine.IndexOf('#') + 1;
            int ageEndIndex = inputLine.IndexOf('*');

            string age = inputLine.Substring(ageStartIndex, (ageEndIndex - ageStartIndex));

            Console.WriteLine($"{name} is {age} years old.");
        }
    }
}