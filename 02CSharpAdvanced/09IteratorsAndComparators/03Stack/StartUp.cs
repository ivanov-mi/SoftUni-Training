using System;
using System.Linq;

namespace IteratorsAndComparators
{
    class StartUp
    {
        static void Main()
        {
            var myStack = new Stack<int>();
            var inputCommand = string.Empty;

            while ((inputCommand = Console.ReadLine())?.ToLower() != "end")
            {
                if (inputCommand.ToLower().StartsWith("push"))
                {
                    var elementsToPush = inputCommand
                        .Split(new char[] {' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Skip(1)
                        .Select(int.Parse);

                    foreach (var element in elementsToPush)
                    {
                        myStack.Push(element);
                    }
                }
                else if(inputCommand.ToLower().StartsWith("pop"))
                {
                    try
                    {
                        myStack.Pop();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var element in myStack)
                {
                    Console.WriteLine(element);
                }
            }
        }
    }
}