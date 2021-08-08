using System;
using System.IO;
using System.Linq;

class EvenLines
{
    static void Main()
    {
        using (var reader = new StreamReader(@"../../../Resourses/text.txt"))
        {
            int lineCounter = 0;
            var symbolsToReplace = new[] { "-", ",", ".", "!", "?" };

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                if (lineCounter % 2 == 0)
                {
                    var words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < words.Length; i++)
                    {
                        string currentWord = words[i];
                        
                        foreach (var ch in symbolsToReplace)
                        {
                            currentWord = currentWord.Replace(ch, "@");
                        }
                        
                        words[i] = currentWord;
                    }

                    string result = string.Join(' ', words.Reverse());
                    Console.WriteLine(result);
                }

                lineCounter++;
            }
        }
    }
}
