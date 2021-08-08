namespace Restaurant
{
    public class Fish : MainDish
    {
        private const double FishDefaultGrams = 22;
        public Fish(string name, decimal price) 
            : base(name, price, FishDefaultGrams)
        {
        }
    }
}