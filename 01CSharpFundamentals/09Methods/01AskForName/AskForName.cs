using System;

class AskForName
{
    static void Main()
    {
        // 01. Write a method that asks the user for his name and prints "Hello, <name>"
        //     (for example, "Hello, Peter!"). Write a program to test this method.

        Console.Write("Input Name:");
        InputName();
    }
    private static void InputName()
    {
        Console.WriteLine($"Hello, {Console.ReadLine()}!");
    }
}