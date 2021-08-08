namespace WildFarm.Models.Animals.Mammals
{
    using System;
    using System.Collections.Generic;

    public class Dog : Mammal
    {
        private const double IncreaseWeight = 0.40;
        private List<string> eatableFood = new List<string> { "Meat", };

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }
        protected override List<string> EatableFood => this.eatableFood;
        protected override double WeightGainPerPieceOfFood => IncreaseWeight;

        public override string ProduceSound() => "Woof!";
    }
}
