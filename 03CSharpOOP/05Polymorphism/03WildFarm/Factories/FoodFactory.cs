namespace WildFarm.Factories
{
    using System;
    using Models.Food;

    public class FoodFactory
    {
        public Food CreateFood(params string[] foodArgs)
        {
            string type = foodArgs[0];
            int quantity = int.Parse(foodArgs[1]);

            switch (type?.ToLower())
            {
                case "fruit":
                    return new Fruit(quantity);

                case "meat":
                    return new Meat(quantity);

                case "seeds":
                    return new Seeds(quantity);

                case "vegetable":
                    return new Vegetable(quantity);

                default:
                    throw new ArgumentException("Invalid food type!");
            }
        }
    }
}
