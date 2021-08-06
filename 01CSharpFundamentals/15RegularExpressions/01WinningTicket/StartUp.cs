using System;
using System.Text.RegularExpressions;

class StartUp
{
    static void Main()
    {
        string[] collectionOfTickets = Console.ReadLine()
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        string winPattern = @"([\@]{6,10})|([\#]{6,10})|([\$]{6,10})|([\^]{6,10})";

        foreach (var ticket in collectionOfTickets)
        {
            if (ticket.Length != 20)
            {
                Console.WriteLine("invalid ticket");
            }
            else
            {
                string leftHalf = ticket.Substring(0, 10);
                string rightHalf = ticket.Substring(10, 10);

                Match leftHalfMatch = Regex.Match(leftHalf, winPattern);
                Match rightHalfMatch = Regex.Match(rightHalf, winPattern);

                if(leftHalfMatch.Length == 10 && rightHalfMatch.Length == 10 && leftHalfMatch.Value == rightHalfMatch.Value)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - {leftHalfMatch.Length}{leftHalfMatch.Value.ToString()[0]} Jackpot!");
                }
                else if(leftHalfMatch.Length >= 6 && rightHalfMatch.Length >= 6 && leftHalfMatch.Value.ToString()[0] == rightHalfMatch.Value.ToString()[0])
                {
                     Console.WriteLine($"ticket \"{ticket}\" - {Math.Min(leftHalfMatch.Length, rightHalfMatch.Length)}{leftHalfMatch.Value.ToString()[0]}");
                }
                else
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }
            }
        }
    }        
}
