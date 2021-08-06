using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        int numberOfDragons = int.Parse(Console.ReadLine());

        Dictionary<string, Dictionary<string, int[]>> dragonArmy = new Dictionary<string, Dictionary<string, int[]>>();

        FillDragonArmy(numberOfDragons, dragonArmy);

        foreach (var dragonType in dragonArmy)
        {
            double averageDamage = dragonType.Value.Average(x => x.Value[0]);
            double averageHealth = dragonType.Value.Average(x => x.Value[1]);
            double averageArmor = dragonType.Value.Average(x => x.Value[2]);

            Console.WriteLine($"{dragonType.Key}::({averageDamage:F2}/{averageHealth:F2}/{averageArmor:F2})");

            foreach (var dragon in dragonType.Value.OrderBy(x => x.Key))
            {
                Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value[0]}, health: {dragon.Value[1]}, armor: {dragon.Value[2]}");
            }
        }
    }

    static void FillDragonArmy(int numberOfDragons, Dictionary<string, Dictionary<string, int[]>> dragonArmy)
    {
        for (int i = 0; i < numberOfDragons; i++)
        {
            string[] inputLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string dragonType = inputLine[0];
            string dragonName = inputLine[1];

            int damage = int.TryParse(inputLine[2], out damage) ? damage : 45;
            int health = int.TryParse(inputLine[3], out health) ? health : 250;
            int armor = int.TryParse(inputLine[4], out armor) ? armor : 10;

            if (dragonArmy.ContainsKey(dragonType) == false)
            {
                dragonArmy.Add(dragonType, new Dictionary<string, int[]>
                {
                    {
                        dragonName,
                        new int[] {damage, health, armor}
                    }
                });
            }
            else if (dragonArmy[dragonType].ContainsKey(dragonName) == false)
            {
                dragonArmy[dragonType].Add(dragonName, new int[] { damage, health, armor });
            }
            else if (dragonArmy[dragonType].ContainsKey(dragonName))
            {
                dragonArmy[dragonType][dragonName] = new int[] { damage, health, armor };
            }
        }
    }
}