namespace WildFarm.Contracts
{
    using Models.Food;

    public interface IAnimal
    {
        public string Name { get; }
        public double Weight { get; }
        public int FoodEaten { get; }
        public abstract string ProduceSound();
        public abstract void FeedAnimal(Food food);
    }
}
