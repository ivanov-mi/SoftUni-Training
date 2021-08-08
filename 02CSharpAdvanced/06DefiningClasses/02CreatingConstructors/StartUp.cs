using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            var firstPerson = new Person()
            {
                Name = "Pesho",
                Age = 20
            };
            var secondPerson = new Person()
            {
                Name = "Gosho",
                Age = 18
            };
            var thirdPerson = new Person()
            {
                Name = "Stamat",
                Age = 43
            };
        }
    }
}
