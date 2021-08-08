namespace Telephony.Core
{
    using System;
    using Models;

    public class Engine
    {
        public void Run()
        {
            var smartphone = new Smartphone();
            var stationaryPhone = new StationaryPhone();

            var phoneNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var number in phoneNumbers)
            {
                try
                {
                    string result = string.Empty;

                    if (number.Length == 7)
                    {
                        result = stationaryPhone.Calling(number);
                    }
                    else if (number.Length == 10)
                    {
                        result = smartphone.Calling(number);
                    }

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            var urls = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(url));                
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
}
