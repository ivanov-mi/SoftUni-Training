using System;

class SieveOfEratosthenes
{
    static void Main()
    {
        //14. Write a program that finds all prime numbers in the range [1...10 000 000].
        //    Use the sieve of Eratosthenes algorithm (find it in Wikipedia).
        bool[] prime = new bool[10000];

        for (int i = 0; i < prime.Length; i++)
        {
            prime[i] = true;
        }

        for (int i = 2; i*i < prime.Length; i++)
        {
            if (prime[i])
            {
                for (int j = i*2; j < prime.Length; j+=i)
                {
                    prime[j] = false;
                }
            }
        }

        for (int i = 2; i < prime.Length; i++)
        {
            if (prime[i])
            {
                Console.Write("{0} ", i);
            }
        }        
    }
}