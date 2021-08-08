using System;
using System.IO;
using System.Linq;

class LineNumbers
{
    static void Main()
    {
        string inputPath = @"../../../Resourses/text.txt";

        Directory.CreateDirectory(@"../../../Output");
        string outputPath = @"../../../Output/output.txt";

        var text = File.ReadAllLines(inputPath);
        int counter = 1;

        for (int i = 0; i < text.Length; i++)
        {        
            int letters = text[i].Count(char.IsLetter);
            int punctuationsMarks = text[i].Count(char.IsPunctuation);
        
            text[i] = $"Line {counter}:" + text[i] + $" ({letters})({punctuationsMarks})";

            counter++;
        }

        File.WriteAllLines(outputPath, text);
    }
}

