using System;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main()
        {
            var name = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var ID = Console.ReadLine();
            var birthday = Console.ReadLine();

            IIdentifiable identifiable = new Citizen(name, age, ID, birthday);
            IBirthable birthable = new Citizen(name, age, ID, birthday);

            Console.WriteLine(identifiable.Id);
            Console.WriteLine(birthable.Birthdate);
        }
    }
}
