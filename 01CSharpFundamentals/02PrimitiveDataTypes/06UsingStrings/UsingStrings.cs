using System;

class ZaribaAcademy
{
    static void Main()
    {
        // 6. Declare two string variables and assign them with "Zariba" and "Academy". Declare an object variable and
        //    assign it with the concatenation of the first two variables (mind adding an interval). Declare a third 
        //    string variable and initialize it with the value ot the objecvt variable (you should perform type casting).

        string firstString = "Zariba";
        string secondString = "Academy";
        object simpleObject = firstString + " " + secondString;
        string thirdString = (string)simpleObject;
    }
}