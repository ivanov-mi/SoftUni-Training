using System;

class Variables
{
    static void Main()
    {
        // 1. Declare a variable for each of the data types in this lecture and assign an appropriate value.
        // Number types
        sbyte simpleSbyteVariable = -127;
        byte simpleByteVariable = 0b_1000_0001;  // 129 in binary
        short simpleShortVariable = 0x3EB;       // 1000  in hexadecimal
        ushort ushortVariable = ushort.MaxValue;
        int simpleInteger = 4_294_563;           // Using '_' as digit seperator
        uint unsignedInteger = 4_294_563_293;
        long simpleLongVariable = (long)Math.Pow(2, 56);
        ulong unsignedLongVariable = 18446744073709551615uL;
      
        // Floating-point types
        float simpleFloatVariable = 3.91102f;
        double simpleDoubleVariable = 4.754e-2;
        decimal simpleDecimalVariable = (decimal)Math.PI;

        // Boolean TYpe
        bool samothingIsItTrue = true;

        // Char 
        char someCharVariable = 'a';
        char otherCharVariable = (char)65;

        // String
        string simpleString = "Hello C#!";
        string differentString = @"Cited string \n";
        string anotherString = "Hello" + " to " + "C#";

        // Object
        object someObject = "A kind of string";

        // var
        var a = "aafeg"; // String
        var b = true; // Boolean
        var c = 3.14f; //Float

    }
}