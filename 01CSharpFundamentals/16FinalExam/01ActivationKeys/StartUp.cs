using System;

class StartUp
{
    static void Main()
    {
        string rawActivationKey = Console.ReadLine();
        string inputLine;

        while ((inputLine = Console.ReadLine())?.ToLower() != "generate")
        {
            string[] instructions = inputLine
                .Split(">>>", StringSplitOptions.RemoveEmptyEntries);
            string instructionCase = instructions[0];

            switch (instructionCase.ToLower())
            {
                case "contains":
                    Contains(rawActivationKey, instructions);
                    break;

                case "flip":
                    rawActivationKey = Flip(rawActivationKey, instructions);
                    break;

                case "slice":
                    rawActivationKey = Slice(rawActivationKey, instructions);
                    break;
            }
        }

        Console.WriteLine($"Your activation key is: {rawActivationKey}");
    }

    private static void Contains(string rawActivationKey, string[] instructions)
    {
        string substring = instructions[1];

        if (rawActivationKey.Contains(substring))
        {
            Console.WriteLine($"{rawActivationKey} contains {substring}");
        }
        else
        {
            Console.WriteLine("Substring not found!");
        }
    }

    private static string Flip(string rawActivationKey, string[] instructions)
    {
        string upperOrLower = instructions[1];
        int startIndex = int.Parse(instructions[2]);
        int endIndex = int.Parse(instructions[3]);

        string replaceString = rawActivationKey[startIndex..endIndex];

        if (upperOrLower.ToLower() == "upper")
        {
            replaceString = replaceString.ToUpper();
        }
        else
        {
            replaceString = replaceString.ToLower();
        }

        rawActivationKey = rawActivationKey.Replace(rawActivationKey[startIndex..endIndex], replaceString);
        Console.WriteLine(rawActivationKey);

        return rawActivationKey;
    }

    private static string Slice(string rawActivationKey, string[] instructions)
    {
        int startIndex = int.Parse(instructions[1]);
        int endIndex = int.Parse(instructions[2]);

        rawActivationKey = rawActivationKey.Remove(startIndex, (endIndex - startIndex));
        Console.WriteLine(rawActivationKey);

        return rawActivationKey;
    }
}