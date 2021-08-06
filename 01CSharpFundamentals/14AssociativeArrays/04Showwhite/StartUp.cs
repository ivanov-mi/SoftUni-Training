using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, int>> dwarfs = new Dictionary<string, Dictionary<string, int>>();

        AddDwarfs(dwarfs);

        var sortedDwarfsCollection = dwarfs
            .OrderByDescending(x => x.Value.Count())
            .SelectMany(x => x.Value, (dwarfHatColor, nameAndPhysics) => new
            {
                dwarfHatColor.Key,
                nameAndPhysics
            })
            .OrderByDescending(x => x.nameAndPhysics.Value);

        foreach (var dwarf in sortedDwarfsCollection)
        {
            Console.WriteLine($"({dwarf.Key}) {dwarf.nameAndPhysics.Key} <-> {dwarf.nameAndPhysics.Value}");
        }
    }

    static void AddDwarfs(Dictionary<string, Dictionary<string, int>> dwarfs)
    {
        string inputLine = string.Empty;

        while ((inputLine = Console.ReadLine()).ToLower() != "once upon a time")
        {
            string[] inputStringArray = inputLine.Split(new char[] { ' ', '<', ':', '>' }, 
                        StringSplitOptions.RemoveEmptyEntries);
            string dwarfName = inputStringArray[0];
            string dwarfHatColor = inputStringArray[1];
            int dwarfPhysics = int.Parse(inputStringArray[2]);

            if (dwarfs.ContainsKey(dwarfHatColor) == false)
            {
                dwarfs.Add(dwarfHatColor, new Dictionary<string, int>
                {
                    { dwarfName, dwarfPhysics }
                });
            }
            else if (dwarfs[dwarfHatColor].ContainsKey(dwarfName) == false)
            {
                dwarfs[dwarfHatColor].Add(dwarfName, dwarfPhysics);
            }
            else if (dwarfs[dwarfHatColor][dwarfName] < dwarfPhysics)
            {
                dwarfs[dwarfHatColor][dwarfName] = dwarfPhysics;
            }
        }
    }
}