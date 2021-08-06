using System;
using System.Collections.Generic;

class TakeSkipRope
{
    static void Main(string[] args)
    {
        string inputString = Console.ReadLine();
        List<int> numbersList = new List<int>();
        List<char> nonNumberList = new List<char>();

        for (int i = 0; i < inputString.Length; i++)
        {
            if (inputString[i]>= '0' && inputString[i] <= '9')
            {
                numbersList.Add(inputString[i] - '0');
            }
            else
            {
                nonNumberList.Add(inputString[i]);
            }
        }

        List<int> takeList = new List<int>(numbersList.Count / 2);
        List<int> skipList = new List<int>(numbersList.Count / 2);

        for (int i = 0; i < numbersList.Count; i++)
        {
            if (i % 2 == 0)
            {
                takeList.Add(numbersList[i]);
            }
            else
            {
                skipList.Add(numbersList[i]);
            }
        }

        string decryptedMessage = string.Join("", DecryptingMessage(nonNumberList, takeList, skipList));
        Console.WriteLine(decryptedMessage);
    }

    public static List<char> DecryptingMessage(List<char> nonNumberList, List<Int32> takeList, List<Int32> skipList)
    {
        int takeEndIndex = 0;

        for (int i = 0; i < takeList.Count; i++)
        {
            takeEndIndex += takeList[i];

            if (takeEndIndex > nonNumberList.Count - 1)
            {
                takeEndIndex = nonNumberList.Count - 1;
                break;
            }
            else if (takeEndIndex + skipList[i] > nonNumberList.Count - 1)
            {
                skipList[i] = nonNumberList.Count - takeEndIndex;
                nonNumberList.RemoveRange(takeEndIndex, nonNumberList.Count - takeEndIndex);
            }
            else
            {
            nonNumberList.RemoveRange(takeEndIndex, skipList[i]);
            }
        }

        if (takeEndIndex < nonNumberList.Count - 1)
        {
            nonNumberList.RemoveRange(takeEndIndex, nonNumberList.Count - takeEndIndex);
        }

        return nonNumberList;
     }
}