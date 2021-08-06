using System;
using System.Linq;

class BasicMathFunctions
    {
        static void Main()
        {
        //04. Write a methods to calculate minimum, maximum, avarage, sum and product of
        //    given set of integer numbers. Use variable number of arguments.

        Console.Write("Input integer numbers: ");
        int[] arrayOfIntegers = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                                                  
        //Find the minimum value                  
        int min = MinimumNumber(arrayOfIntegers);
        Console.WriteLine($"The minimum number is: {min}");

        //Find the maximum value
        int max = MaximumNumber(arrayOfIntegers);
        Console.WriteLine($"The maximum number is: {max}");

        //Find the average
        double average = Average(arrayOfIntegers);
        Console.WriteLine($"The average of the set of numbers is: {average}");

        //Find the sum
        long sum = SumOfNumbers(arrayOfIntegers);
        Console.WriteLine($"The sum of the numbers is: {sum}");

        //Find the product
        long product = ProductOfNumbers(arrayOfIntegers);
        Console.WriteLine($"The product of the numbers is: {product}");
    }

    private static long ProductOfNumbers(params int[] arrayOfIntegers)
    {
        long product = 1;
        foreach (var number in arrayOfIntegers)
        {
            product *= number;
        }

        return product;
    }

    private static long SumOfNumbers(params int[] arrayOfIntegers)
    {
        long sum = 0;
        foreach (var number in arrayOfIntegers)
        {
            sum += number;
        }

        return sum;
    }

    private static double Average(params int[] arrayOfIntegers)
    {
        int sum = 0;
        int counter = 0;
        foreach (var number in arrayOfIntegers)
        {
            sum += number;
            counter++;
        }

        return (double)sum / counter;
    }

    private static int MaximumNumber(params int[] arrayOfIntegers)
    {
        int max = Int32.MinValue;
        foreach (var number in arrayOfIntegers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        return max;
    }

    private static int MinimumNumber(params int[] arrayOfIntegers)
    {
        int min = Int32.MaxValue;
        foreach (var number in arrayOfIntegers)
        {
            if (number < min)
            {
                min = number;
            }
        }

        return min;
    }
}