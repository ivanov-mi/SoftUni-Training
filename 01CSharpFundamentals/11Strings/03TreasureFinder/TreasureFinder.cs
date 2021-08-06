using System;
using System.Text;

class TreasureFinder
{
    static void Main()
    {
        char[] key = Console.ReadLine()
            .Replace(" ", string.Empty)
            .ToCharArray();

        string inputLine = string.Empty;

       while ((inputLine = Console.ReadLine())?.ToLower() != "find")
       {
           StringBuilder sb = new StringBuilder(inputLine.Length);
       
           for (int i=0; i < inputLine.Length; i++) 
           {
               sb.Append((char)(inputLine[i] - key[i % key.Length] + '0'));
           }

           string decodedMessage = sb.ToString();

           int startTreasureIndex = decodedMessage.IndexOf('&') + 1;
           int endTreasureIndex = decodedMessage.LastIndexOf('&');
           string treasure = decodedMessage.Substring(startTreasureIndex, (endTreasureIndex - startTreasureIndex));

           int startCoordinatesIndex = decodedMessage.IndexOf('<') + 1;
           int endCoordinatesIndex = decodedMessage.LastIndexOf('>');
           string coordinates = decodedMessage.Substring(startCoordinatesIndex, (endCoordinatesIndex - startCoordinatesIndex));

           Console.WriteLine($"Found {treasure} at {coordinates}");
       }
    }
}