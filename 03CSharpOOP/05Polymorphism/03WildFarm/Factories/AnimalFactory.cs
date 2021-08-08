namespace WildFarm.Factories
{
    using System;
    using Models.Animals.Mammals;
    using Models.Animals.Mammals.Felines;
    using Models.Animals;
    using Models.Animals.Birds;

    class AnimalFactory
    {
        public Animal CreateAnimal(params string[] foodArgs)
        {
            string type = foodArgs[0];
            string name = foodArgs[1];
            double weight = double.Parse(foodArgs[2], System.Globalization.CultureInfo.InvariantCulture);
            double wingSize;
            string livingRegion;
            string breed;

            switch (type?.ToLower())
            {
                case "hen":
                    wingSize = double.Parse(foodArgs[3], System.Globalization.CultureInfo.InvariantCulture);
                    return new Hen(name, weight, wingSize);

                case "owl":
                    wingSize = double.Parse(foodArgs[3], System.Globalization.CultureInfo.InvariantCulture);
                    return new Owl(name, weight, wingSize);

                case "mouse":
                    livingRegion = foodArgs[3];
                    return new Mouse(name, weight, livingRegion);

                case "cat":
                    livingRegion = foodArgs[3];
                    breed = foodArgs[4];
                    return new Cat(name, weight, livingRegion, breed);

                case "dog":
                    livingRegion = foodArgs[3];
                    return new Dog(name, weight, livingRegion);

                case "tiger":
                    livingRegion = foodArgs[3];
                    breed = foodArgs[4];
                    return new Tiger(name, weight, livingRegion, breed);

                default:
                    throw new ArgumentException("Invalid animal type!");
            }
        }
    }
}
