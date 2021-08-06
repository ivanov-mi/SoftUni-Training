using System;

class SwapValues
{
    static void Main()
    {
        // 9. Read two integer values from the console and exchange their values.

        int firstValue = int.Parse(Console.ReadLine());
        int secontValue = int.Parse(Console.ReadLine());
        int tmp = secontValue;
        secontValue = firstValue;
        firstValue = tmp;
    }
}