using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var vloggersData = new List<VLogger>();
        string inputLine = string.Empty;

        while ((inputLine = Console.ReadLine())?.ToLower() != "statistics")
        {
            if (inputLine.EndsWith(" joined The V-Logger"))
            {
                var name = inputLine
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .FirstOrDefault();

                if (!vloggersData.Any(x => x.Name == name))
                {
                    vloggersData.Add(new VLogger(name));
                }
            }
            else
            {
                var secondVlogger = inputLine
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .FirstOrDefault();
                var firstVlogger = inputLine
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .LastOrDefault();
                if (vloggersData.Any(x => x.Name == firstVlogger) && vloggersData.Any(x => x.Name == secondVlogger))
                {                    
                    var newFollower = vloggersData.FirstOrDefault(x => x.Name == firstVlogger);
                    newFollower.AddFollower(secondVlogger);

                    var newFollowing = vloggersData.FirstOrDefault(x => x.Name == secondVlogger);
                    newFollowing.Follow(firstVlogger);
                }              
            }
        }

        Console.WriteLine($"The V-Logger has a total of {vloggersData.Count} vloggers in its logs.");

        var famousVlogger = vloggersData.OrderByDescending(x => x.Followers.Count())
            .ThenBy(x => x.Following.Count())
            .FirstOrDefault();

        if (famousVlogger.Followers.Count > 0)
        {
            int i = 1;

            Console.WriteLine($"{i}. {famousVlogger.Name} : {famousVlogger.Followers.Count} " +
                $"followers, {famousVlogger.Following.Count} following");

            foreach (var follower in famousVlogger.Followers)
            {
                Console.WriteLine($"*  {follower}");
            }

            vloggersData.Remove(famousVlogger);
            i++;

            foreach (var vlogger in vloggersData.OrderByDescending(x => x.Followers.Count())
                .ThenBy(x => x.Following.Count()))
            {
                Console.WriteLine($"{i}. {vlogger.Name} : {vlogger.Followers.Count} " +
                    $"followers, {vlogger.Following.Count} following");
                i++;
            }           
        }
    }
}
