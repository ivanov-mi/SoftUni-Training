namespace Telephony.Models
{
    using System;
    using System.Linq;

    using Contracts;

    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string url)
        {
            if (url.Any(char.IsDigit))
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {url}!";
        }

        public string Calling(string phoneNumber)
        {
            if (!phoneNumber.All(char.IsDigit))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Calling... {phoneNumber}";
        }
    }
}
