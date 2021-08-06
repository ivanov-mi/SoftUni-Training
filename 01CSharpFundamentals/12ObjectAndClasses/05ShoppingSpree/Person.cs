using System;
using System.Collections.Generic;

public class Person
{
    public Person(string personName, double money)
    {
        this.Name = personName;
        this.Money = money;
        this.BagOfProducts = new List<string>();
    }

    public string Name { get; set; }
    public double Money { get; set; }
    public List<string> BagOfProducts { get; set; }

    public void PurchaseProduct (string productName, double cost)
    {
        if (Money < cost)
        {
            Console.WriteLine($"{Name} can't afford {productName}");
        }
        else
        {
            Money -= cost;
            BagOfProducts.Add(productName);

            Console.WriteLine($"{Name} bought {productName}");
        }
    }
}