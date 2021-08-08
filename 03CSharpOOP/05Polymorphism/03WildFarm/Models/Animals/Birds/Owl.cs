namespace WildFarm.Models.Animals.Birds
{
    using System;
    using System.Collections.Generic;

    public class Owl : Bird
    {
        private const double IncreaseWeight = 0.25;
        private List<string> eatableFood = new List<string> { "Meat", };

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }
        protected override List<string> EatableFood => this.eatableFood;
        protected override double WeightGainPerPieceOfFood => IncreaseWeight;

        public override string ProduceSound() => "Hoot Hoot";
    }
}
