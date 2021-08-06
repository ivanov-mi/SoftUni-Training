using System;
using System.Collections.Generic;
using System.Linq;

class DrumSetState
{
    static void Main()
    {
        double savings = double.Parse(Console.ReadLine());
        List<int> initialQuality = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        List<int> drumsetPrice = new List<int>(initialQuality.Count);

        for (int i = 0; i < initialQuality.Count; i++)
        {
            drumsetPrice.Add(initialQuality[i] * 3);
        }        

        string inputLine = string.Empty;

        while ((inputLine = Console.ReadLine()) != "Hit it again, Gabsy!")
        {
            int hitPower = int.Parse(inputLine);

            for (int i = 0; i < initialQuality.Count; i++)
            {
                initialQuality[i] -= hitPower;
                if (initialQuality[i] <= 0 && savings >= drumsetPrice[i])
                {
                    savings -= drumsetPrice[i];
                    initialQuality[i] = drumsetPrice[i] / 3;
                }
                else if (initialQuality[i] <= 0 && savings < drumsetPrice[i])
                {
                    initialQuality.RemoveAt(i);
                    drumsetPrice.RemoveAt(i);
                    i--;
                }
            }
            if (initialQuality.Count == 0)
            {
                break;
            }
        }

        Console.WriteLine(string.Join(' ', initialQuality));
        Console.WriteLine($"Gabsy has {savings:f2}lv.");
    }
}