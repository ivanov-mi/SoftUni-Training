namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Models.Food;

    public abstract class Animal : IAnimal
    {
        private const double IncreaseWeight = 0;
        private List<string> eatableFood;

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
            this.eatableFood = new List<string>();
        }

        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        protected virtual List<string> EatableFood => this.eatableFood;

        protected virtual double WeightGainPerPieceOfFood
            => IncreaseWeight;

        public abstract string ProduceSound();

        public void FeedAnimal(Food food)
        {
            if (this.EatableFood.Contains(food.GetType().Name.ToString()) == false)
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * this.WeightGainPerPieceOfFood; 
        }
    }
}
