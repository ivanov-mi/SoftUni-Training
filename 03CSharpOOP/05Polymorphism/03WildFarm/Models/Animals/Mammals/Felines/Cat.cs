namespace WildFarm.Models.Animals.Mammals.Felines
{
    using System;
    using System.Collections.Generic;

    public class Cat : Feline
    {
        private const double IncreaseWeight = 0.30;
        private List<string> eatableFood = new List<string> { "Vegetable", "Meat", };

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override List<string> EatableFood => this.eatableFood;
        protected override double WeightGainPerPieceOfFood => IncreaseWeight;

        public override string ProduceSound() => "Meow";
    }
}
