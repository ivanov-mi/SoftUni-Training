using System;
using System.Globalization;

namespace _05.DateModifier
{
    public class DateModifier
    {  
        public static int GetDaysBetweenDates(string firstDate, string secondDate)
        {
            var d1 = DateTime.ParseExact(firstDate, "yyyy MM dd", CultureInfo.InvariantCulture);
            var d2 = DateTime.ParseExact(secondDate, "yyyy MM dd", CultureInfo.InvariantCulture);

            var differenceInDays = (int)Math.Abs((d1 - d2).TotalDays);

            return differenceInDays;
        }
    }
}
