using System;
using System.Linq;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main()
        {
            try
            {
                CreatePizza pizza = MakeNewPizza();

                var inputTopping = Console.ReadLine();

                while (inputTopping?.ToLower() != "end")
                {
                    AddToping(pizza, inputTopping);

                    inputTopping = Console.ReadLine();
                }

                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddToping(CreatePizza pizza, string inputTopping)
        {
            var toppingProperties = inputTopping
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var toppingType = toppingProperties[1];
            var toppingWeight = double.Parse(toppingProperties[2]);

            var topping = new Topping(toppingType, toppingWeight);

            pizza.AddTopping(topping);
        }

        private static CreatePizza MakeNewPizza()
        {
            var pizzaName = Console.ReadLine()
                .Split()
                .Skip(1)
                .FirstOrDefault();               

            var doughProperties = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var flourType = doughProperties[1];
            var bakingTechnique = doughProperties[2];
            var doughWeight = double.Parse(doughProperties[3]);

            Dough dough = new Dough(flourType, bakingTechnique, doughWeight);

            CreatePizza pizza = new CreatePizza(pizzaName, dough);

            return pizza;
        }
    }
}
