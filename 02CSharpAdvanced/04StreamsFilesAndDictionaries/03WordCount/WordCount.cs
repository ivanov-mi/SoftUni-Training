using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class WordCount
{
    static void Main()
    {
        var searchedWordsPath = @"../../../Resourses/words.txt";
        var textPath = @"../../../Resourses/text.txt";

        var searchedWords = File.ReadAllLines(searchedWordsPath);
        var text = File.ReadAllText(textPath);

        var wordsCount = new Dictionary<string, int>(searchedWords.Length);

        foreach (var word in searchedWords)
        {
            string lowercaseWord = word.ToLower();

            if (!wordsCount.ContainsKey(lowercaseWord))
            {
                wordsCount.Add(lowercaseWord, 0);
            }
        }

        var punctuations = text.Where(char.IsPunctuation)
            .Distinct()
            .ToArray();
        var textArray = text.Split(new string[] {" ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim(punctuations));

        foreach (var word in textArray)
        {
            string lowercaseWord = word.ToLower();

            if (wordsCount.ContainsKey(lowercaseWord))
            {
                wordsCount[lowercaseWord]++;
            }
        }

        Directory.CreateDirectory(@"../../../Output");
        var actualResultPath = @"../../../Output/actualResult.txt";
        var expectedResultPath = @"../../../Output/expectedResult.txt";

        var actualResultOutput = string.Empty;
        var expectedResultOutput = string.Empty;

        foreach (var word in wordsCount)
        {
            actualResultOutput += $"{word.Key} - {word.Value}{Environment.NewLine}";
        }
        File.WriteAllText(actualResultPath, actualResultOutput);

        foreach (var word in wordsCount.OrderByDescending(x => x.Value))
        {
            expectedResultOutput += $"{word.Key} - {word.Value}{Environment.NewLine}";
        }
        File.WriteAllText(expectedResultPath, expectedResultOutput);
    }
}

