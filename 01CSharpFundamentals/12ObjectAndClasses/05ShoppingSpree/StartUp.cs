using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        List<Person> listOfPersons = new List<Person>();
        string[] inputPersons = Console.ReadLine()
            .Split(new string[] {";", " " }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < inputPersons.Length; i++)
        {
            string[] inputNewPerson = inputPersons[i].Split(new string[] { "=", " " }, StringSplitOptions.RemoveEmptyEntries);
            Person newPerson = new Person(inputNewPerson[0], double.Parse(inputNewPerson[1]));
            listOfPersons.Add(newPerson);
        }

        List<Product> listOfProducts = new List<Product>();
        string[] inputProducts = Console.ReadLine()
            .Split(new string[] { ";", " " }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < inputProducts.Length; i++)
        {
            string[] inputNewProduct = inputProducts[i]
                .Split(new string[] { "=", " "}, StringSplitOptions.RemoveEmptyEntries);

            Product newProduct = new Product(inputNewProduct[0], double.Parse(inputNewProduct[1]));
            listOfProducts.Add(newProduct);
        }

        string inputLine = string.Empty;
        List<string> purchases = new List<string>();

        while ((inputLine = Console.ReadLine()) != "END")
        {
            purchases.Add(inputLine);
        }

        for (int i = 0; i < purchases.Count; i++)
        {
            string[] currentPurchase = purchases[i]
                .Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);

            Person currentPerson = listOfPersons
                .Where(x => x.Name == currentPurchase[0]).FirstOrDefault(); 
            
            Product currentProduct = listOfProducts
                .Where(x => x.Name == currentPurchase[1]).FirstOrDefault();
            
            currentPerson.PurchaseProduct(currentProduct.Name, currentProduct.Cost);
        }

        foreach (var person in listOfPersons)
        {
            Console.Write($"{person.Name} - ");

            if (person.BagOfProducts.Count == 0)
            {
                Console.WriteLine("Nothing bought");
            }
            else
            {
                Console.WriteLine(string.Join(", ", person.BagOfProducts));
            }
        }
    }
}