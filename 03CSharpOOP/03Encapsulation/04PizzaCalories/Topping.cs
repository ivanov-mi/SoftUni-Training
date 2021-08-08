using System;

namespace PizzaCalories
{
    public class Topping
    {
        private const double BaseCaloriesPerGram = 2.0;
        private const int MinToppingWeight = 1;
        private const int MaxToppingWeight = 50;

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type 
        { 
            get => this.type;
            private set
            {
                this.ValidateType(value);

                this.type = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                this.ValidateWeight(value);

                this.weight = value;
            }
        }

        public double GetCalories()
            => BaseCaloriesPerGram * this.GetTypeModifier() * this.Weight;

        private double GetTypeModifier()
        {
            switch (this.type.ToLower())
            {
                case "meat": 
                    return 1.2;
                case "veggies":
                    return 0.8;
                case "cheese":
                   return 1.1;
                case "sauce":
                    return 0.9;
                default:
                    return 0;
            }
        }

        private void ValidateType(string type)
        {
            if (type.ToLower() != "meat"
                && type.ToLower() != "veggies"
                && type.ToLower() != "cheese"
                && type.ToLower() != "sauce")
            {
                throw new ArgumentException($"Cannot place {type} on top of your pizza.");
            }
        }

        private void ValidateWeight(double weight)
        {
            if (weight < MinToppingWeight || weight > MaxToppingWeight)
            {
                throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
            }
        }
    }
}
