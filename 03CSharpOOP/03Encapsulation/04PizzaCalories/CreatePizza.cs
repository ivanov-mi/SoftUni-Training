using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class CreatePizza
    {
        private const int MaxToppingsCount = 10;
        private const int MinNameLength = 1;
        private const int MaxNameLength = 15;

        private string name;
        private List<Topping> toppings;

        public CreatePizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public int NumberOfToppings => this.toppings.Count;

        public string Name 
        { 
            get => this.name;
            private set
            {
                this.ValidateName(value);

                this.name = value;
            }
        }

        public Dough Dough { get; set; }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count >= MaxToppingsCount)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }

        public double GetTotalCalories() 
            => this.Dough.GetCalories() + this.toppings.Sum(x => x.GetCalories());

        public override string ToString()
        {
            return $"{this.Name} - {this.GetTotalCalories():F2} Calories.";
        }

        private void ValidateName(string name)
        {
            if (name.Length < MinNameLength 
                || name.Length > MaxNameLength 
                || string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
        }
    }
}
