namespace FoodShortage.Contracts
{
    public interface IBuyer : IIdentifiable
    {
        public int Food { get; }
        public void BuyFood();
    }
}
