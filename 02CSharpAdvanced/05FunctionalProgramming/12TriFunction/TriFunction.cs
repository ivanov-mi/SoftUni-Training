using System;
using System.Linq;


class TriFunction
{
    static void Main()
    {
        var givenNumber = int.Parse(Console.ReadLine());
        var names = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        Func<string, int, bool> isEqualOrLarger = (name, number) => name.ToCharArray()
                                                                         .Select(x => (int)x)
                                                                         .Sum() >= number;
        var name = checkWord(names, givenNumber, isEqualOrLarger);

        Console.WriteLine(name);
    }

    private static string checkWord(string[] names, int number, Func<string, int, bool> isEqualOrLarger)
    {
        return names.Where(name => isEqualOrLarger(name, number))
                    .FirstOrDefault();
    }
}
