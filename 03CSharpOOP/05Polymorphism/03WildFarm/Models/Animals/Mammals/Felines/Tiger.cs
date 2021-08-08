namespace WildFarm.Models.Animals.Mammals.Felines
{
    using System;
    using System.Collections.Generic;

    public class Tiger : Feline
    {
        private const double IncreaseWeight = 1.0;
        private List<string> eatableFood = new List<string> { "Meat", };

        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }
        protected override List<string> EatableFood => this.eatableFood;
        protected override double WeightGainPerPieceOfFood => IncreaseWeight;

        public override string ProduceSound() => "ROAR!!!";
    }
}
