using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main()
        {
            var people = new List<Person>();
            var products = new List<Product>();

            try
            {
                AddPeople(people);

                AddProducts(products);

                while (true)
                {
                    var commandsInput = Console.ReadLine();

                    if (commandsInput?.ToLower() == "end")
                    {
                        break;
                    }

                    PersonBuyingProduct(people, products, commandsInput);
                }

                PrintResult(people);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PersonBuyingProduct(List<Person> people, List<Product> products, string commandsInput)
        {
            var commands = commandsInput.Split();
            var personName = commands[0];
            var productName = commands[1];

            var person = people.FirstOrDefault(p => p.Name == personName);
            var product = products.FirstOrDefault(pr => pr.Name == productName);

            person.AddProduct(product);
        }

        private static void PrintResult(List<Person> people)
        {
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }

        private static void AddProducts(List<Product> products)
        {
            var productsInput = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var product in productsInput)
            {
                var productData = product.Split('=', StringSplitOptions.RemoveEmptyEntries);

                var productName = productData[0];
                var productPrice = decimal.Parse(productData[1]);

                var newProduct = new Product(productName, productPrice);
                products.Add(newProduct);
            }
        }

        private static void AddPeople(List<Person> people)
        {
            var peopleInput = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach (var person in peopleInput)
            {
                var personData = person.Split('=', StringSplitOptions.RemoveEmptyEntries);

                var personName = personData[0];
                var personMoney = decimal.Parse(personData[1]);

                var newPerson = new Person(personName, personMoney);
                people.Add(newPerson);
            }
        }
    }
}
