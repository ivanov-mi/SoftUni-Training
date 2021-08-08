using System;
using System.Linq;

namespace IteratorsAndComparators
{
    class StartUp
    {
        static void Main()
        {
            var inputDataList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToList();

            var listyIterator = new ListyIterator<string>(inputDataList);

            var inputCommand = string.Empty;
            while ((inputCommand = Console.ReadLine())?.ToLower() != "end")
            {
                if (inputCommand.ToLower() == "move")
                {
                    var result = listyIterator.Move();
                    Console.WriteLine(result);
                }
                else if (inputCommand.ToLower() == "print")
                {
                    try
                    {
                        listyIterator.Print();
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                else if (inputCommand.ToLower() == "hasnext")
                {
                    var result = listyIterator.HasNext();
                    Console.WriteLine(result);
                }
            }
        }
    }
}