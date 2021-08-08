using System;

namespace PizzaCalories
{
    public class Dough
    {
        private const double BaseCaloriesPerGram = 2.0;
        private const int MinWeight = 1;
        private const int MaxWeight = 200;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType 
        { 
            get => this.flourType; 
            private set
            {
                this.ValidateFlourType(value);

                this.flourType = value;
            }
        }

        public string BakingTechnique 
        { 
            get => this.bakingTechnique;
            private set
            {
                this.ValidateBakingTechniques(value);

                this.bakingTechnique = value;
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
            => this.Weight * BaseCaloriesPerGram * this.GetFlourTypeModifier() * this.GetBakingTechniqueModifier();

        private double GetFlourTypeModifier()
        {
            switch (this.FlourType.ToLower())
            {
                case "white":
                   return 1.5;
                case "wholegrain":
                    return 1.0;
                default:
                    return 0;
            }
        }

        private double GetBakingTechniqueModifier()
        {
            switch (this.BakingTechnique.ToLower())
            {
                case "crispy":
                    return 0.9;
                case "chewy":
                    return 1.1;
                case "homemade":
                    return 1.0;
                default:
                    return 0;
            }
        }


        private void ValidateFlourType(string flourType)
        {
            if (flourType.ToLower() != "white" && flourType.ToLower() != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
        }

        private void ValidateBakingTechniques(string bakingTechniques)
        {
            if (bakingTechniques.ToLower() != "crispy"
                && bakingTechniques.ToLower() != "chewy"
                && bakingTechniques.ToLower() != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
        }

        private void ValidateWeight(double value)
        {
            if (value < MinWeight || value > MaxWeight)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
        }
    }
}
