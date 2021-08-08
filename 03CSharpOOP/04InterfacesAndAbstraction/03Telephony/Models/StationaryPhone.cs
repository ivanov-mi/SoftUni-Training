namespace Telephony.Models
{
    using System;
    using System.Linq;

    using Contracts;

    public class StationaryPhone : ICallable
    {
        public string Calling(string phoneNumber)
        {
            if (!phoneNumber.All(char.IsDigit))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Dialing... {phoneNumber}";
        }
    }
}
