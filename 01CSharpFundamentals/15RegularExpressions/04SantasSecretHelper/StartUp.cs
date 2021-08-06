using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class StartUp
{
    static void Main()
    {
        int key = int.Parse(Console.ReadLine());

        List<string> goodChildrenList = new List<string>();
        string inputLine = string.Empty;

        while ((inputLine = Console.ReadLine())?.ToLower() != "end")
        {
            string decodedLine = String.Join("", inputLine.Select(x => (char)(x - key)));
            string pattern = @"@(?<name>[A-Za-z]+)[^@\-!:>]*!(?<behavior>[G])!";

            Match goodChild = Regex.Match(decodedLine, pattern);

            if (goodChild.Success)
            {
                goodChildrenList.Add(goodChild.Groups["name"].Value);
            }
        }

        foreach (var child in goodChildrenList)
        {
            Console.WriteLine(child);
        }     
    }
}