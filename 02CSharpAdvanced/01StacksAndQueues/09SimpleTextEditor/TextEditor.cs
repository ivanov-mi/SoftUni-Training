using System;
using System.Collections.Generic;
using System.Text;

class TextEditor
{
    static void Main()
    {
        int numberOfOperations = int.Parse(Console.ReadLine());
        Stack<string> stateStack = new Stack<string>();
        StringBuilder text = new StringBuilder();
        stateStack.Push(string.Empty);

        for (int i = 0; i < numberOfOperations; i++)
        {
            string[] inputLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string command = inputLine[0];

            switch (command)
            {
                case "1":
                    text.Append(inputLine[1]);
                    stateStack.Push(text.ToString());
                    break;

                case "2":
                    int eraseLastElements = int.Parse(inputLine[1]);
                    text.Remove(text.Length - eraseLastElements, eraseLastElements);
                    stateStack.Push(text.ToString());
                    break;

                case "3":
                    int elementAtPosition = int.Parse(inputLine[1]) - 1;
                    Console.WriteLine(text[elementAtPosition]);
                    break;

                case "4":
                    stateStack.Pop();
                    text = new StringBuilder(stateStack.Peek());
                    break;
            }
        }
    }
}

