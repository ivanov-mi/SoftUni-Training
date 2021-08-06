using System;
using System.Collections.Generic;

class HTML
{
    static void Main()
    {
        string heading = Console.ReadLine();
        string article = Console.ReadLine();
        List<string> div = new List<string>();

        string inputLine = string.Empty;

        while ((inputLine = Console.ReadLine())?.ToLower() != "end of comments")
        {
            div.Add(inputLine);
        }

        Console.WriteLine($"<h1>" +
            $"\n   {heading}" +
            "\n</h1>");

        Console.WriteLine($"<article>" +
            $"\n   {article}" +
            $"\n</article>");

        for (int i = 0; i < div.Count; i++)
        {
            Console.WriteLine($"<div>" +
                $"\n   {div[i]}" +
                $"\n</div>");
        }
    }
}