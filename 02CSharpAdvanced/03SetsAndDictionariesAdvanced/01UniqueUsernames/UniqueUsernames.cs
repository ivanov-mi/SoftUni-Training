using System;
using System.Collections.Generic;

class UniqueUsernames
{
    static void Main()
    {
        int numberOfUsernames = int.Parse(Console.ReadLine());
        var usernames = new HashSet<string>();

        for (int i = 0; i < numberOfUsernames; i++)
        {
            usernames.Add(Console.ReadLine());
        }

        foreach (var username in usernames)
        {
            Console.WriteLine(username);
        }
    }
}

