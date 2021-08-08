namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double defaultCakeGrams = 250;
        private const decimal defaultCakePrice = 5M;
        private const double defaultCakeCalories = 1000;
        public Cake(string name) 
            : base(name, defaultCakePrice, defaultCakeGrams, defaultCakeCalories)
        {
        }
    }
}