namespace WildFarm.Models.Animals.Birds
{
    using System;
    using System.Collections.Generic;

    public class Hen : Bird
    {
        private const double IncreaseWeight = 0.35;
        private List<string> eatableFood = new List<string> { "Vegetable", "Fruit", "Meat", "Seeds", };

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }
        protected override List<string> EatableFood => this.eatableFood;
        protected override double WeightGainPerPieceOfFood => IncreaseWeight;

        public override string ProduceSound() => "Cluck";
    }
}
