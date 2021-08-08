using System;
using System.Collections.Generic;

class SongsQueue
{
    static void Main()
    {
        string[] inputSongs = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries);
        Queue<string> songsQueue = new Queue<string>(inputSongs);

        while (songsQueue.Count > 0)
        {
            string[] commandsInput = Console.ReadLine()
                .Split(" ", 2, StringSplitOptions.RemoveEmptyEntries);
            string command = commandsInput[0];

            switch (command)
            {
                case "Play":
                        songsQueue.Dequeue();
                    break;

                case "Add":
                    string songName = commandsInput[1];
                    if (songsQueue.Contains(songName))
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }
                    else
                    {
                        songsQueue.Enqueue(songName);
                    }
                    break;

                case "Show":
                    Console.WriteLine(string.Join(", ", songsQueue));
                    break;
            }
        }

        Console.WriteLine("No more songs!");
    }
}

