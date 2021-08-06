using System;
using System.Linq;

class Kamino
{
    static void Main()
    {
        //  16. * Kamino Factory
        //   The clone factory in Kamino got another order to clone troops.But this time you are tasked to find the best DNA
        //  sequence to use in the production.
        //  You will receive the DNA length and until you receive the command "Clone them!" you will be receiving a DNA
        //  sequences of ones and zeroes, split by "!" (one or several).
        //  You should select the sequence with the longest subsequence of ones.If there are several sequences with same
        //  length of subsequence of ones, print the one with the leftmost starting index, if there are several sequences with
        //  same length and starting index, select the sequence with the greater sum of its elements.
        //  After you receive the last command "Clone them!" you should print the collected information in the following
        //  format:
        //  "Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}."
        //  "{DNA sequence, joined by space}"
        //  
        //  Input / Constraints
        //  - The first line holds the length of the sequences – integer in range[1…100];
        //  - On the next lines until you receive "Clone them!" you will be receiving sequences(at least one) of ones and
        //    zeroes, split by "!" (one or several).
        //  
        //  Output
        //  The output should be printed on the console and consists of two lines in the following format:
        //  "Best DNA sample { bestSequenceIndex} with sum: {bestSequenceSum}"
        //  "{DNA sequence, joined by space}"
        //  
        //  Examples
        //  Input           Output                              Comments
        //  5               Best DNA sample 2 with sum: 2.      We receive 2 sequences with same length of
        //  1!0!1!1!0       0 1 1 0 0                           subsequence of ones, but the second is printed,
        //  0!1!1!0!0                                           because its subsequence starts at index[1].
        //  Clone them!
        //  
        //  Input           Output                              Comments
        //  4               Best DNA sample 1 with sum: 3.      We receive 3 sequences.Both 1 and 3 have same
        //  1!1!0!1         1 1 0 1                             length of subsequence of ones - &gt; 2, and both start
        //  1!0!0!1                                             from index[0], but the first is printed, because its sum
        //  1!1!0!0                                             is greater.
        //  Clone them!

        int length = int.Parse(Console.ReadLine());
        int bestSequenceSum = 0;
        int bestSequenceIndex = 0;
        int longestSubsequentStart = Int32.MaxValue;
        int longestSubsequent = 0;
        int sequenceIndex = 0;
        string inputLine = string.Empty;
        string outputString = string.Empty;

        while ("Clone them!" != (inputLine = Console.ReadLine()))
        {
            sequenceIndex++;

            int[] currentSequence = inputLine
                .Split('!', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int sequenceSum = 0;
            int sequenceMaxSubsequenceStart = 0;
            int sequenceMaxSubsequence = 0;
            int currentSubsequentLegth = 0;

            for (int i = 0; i < length; i++)
            {
                sequenceSum += currentSequence[i];
                
                if (currentSequence[i] == 1)
                {
                    currentSubsequentLegth++;
                    if (currentSubsequentLegth > sequenceMaxSubsequence)
                    {
                        sequenceMaxSubsequence = currentSubsequentLegth;
                        sequenceMaxSubsequenceStart = i - sequenceMaxSubsequence + 1;
                    }
                }
                else
                {
                    currentSubsequentLegth = 0;
                }
            }

            if (sequenceMaxSubsequence > longestSubsequent)
            {
                longestSubsequent = sequenceMaxSubsequence;
                longestSubsequentStart = sequenceMaxSubsequenceStart;
                bestSequenceSum = sequenceSum;
                bestSequenceIndex = sequenceIndex;
                outputString = string.Join(' ', currentSequence);
            }
            else if(sequenceMaxSubsequence == longestSubsequent)
            {
                if (sequenceMaxSubsequenceStart < longestSubsequentStart)
                {                    
                        longestSubsequent = sequenceMaxSubsequence;
                        longestSubsequentStart = sequenceMaxSubsequenceStart;
                        bestSequenceSum = sequenceSum;
                        bestSequenceIndex = sequenceIndex;
                        outputString = string.Join(' ', currentSequence);
                }
                else if (sequenceMaxSubsequenceStart == longestSubsequentStart)
                {
                    if (sequenceSum > bestSequenceSum)
                    {
                        longestSubsequent = sequenceMaxSubsequence;
                        longestSubsequentStart = sequenceMaxSubsequenceStart;
                        bestSequenceSum = sequenceSum;
                        bestSequenceIndex = sequenceIndex;
                        outputString = string.Join(' ', currentSequence);
                    }
                }
            }
        }

        Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}.");
        Console.WriteLine(outputString);
    }
}