using System;

class IndexesOfLetters
{
    static void Main()
    {
        //12. Write a program that creates an array containing all letters from the alphabet (A-Z).
        //    Read a word from the console and print the index of each of its letters in the array.

        char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        string word = Console.ReadLine().ToUpper();

        for (int i = 0; i < word.Length; i++)
        {
            for (int j = 0; j < alphabet.Length; j++)
            {
                if (word[i] == alphabet[j])
                {
                    Console.WriteLine("{0} = {1}", word[i], j);
                }
            }
        }
    }
}