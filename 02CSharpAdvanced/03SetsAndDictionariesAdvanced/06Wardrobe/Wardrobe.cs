using System;
using System.Collections.Generic;
using System.Linq;

class Wardrobe
{
    static void Main()
    {
        int numberOfColors = int.Parse(Console.ReadLine());
        var wardrobe = new Dictionary<string, Dictionary<string, int>>();

        for (int i = 0; i < numberOfColors; i++)
        {
            var inputLine = Console.ReadLine()
                .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
            string color = inputLine[0];
            var clothes = inputLine[1]
                .Split(",", StringSplitOptions.RemoveEmptyEntries);

            if (!wardrobe.ContainsKey(color))
            {
                wardrobe.Add(color, new Dictionary<string, int>());
            }

            foreach (var item in clothes)
            {
                if (!wardrobe[color].ContainsKey(item))
                {
                    wardrobe[color].Add(item, 0);
                }

                wardrobe[color][item]++;
            }
        }

        var searchedItem = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string seachedColor = searchedItem[0];
        string searchedClothing = searchedItem[1];

        foreach (var color in wardrobe)
        {
            Console.WriteLine($"{color.Key} clothes:");

            foreach (var item in color.Value)
            {
                if (color.Key == seachedColor && item.Key == searchedClothing)
                {
                    Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                }
                else
                {
                    Console.WriteLine($"* {item.Key} - {item.Value}");
                }
            }
        }

    }
}
