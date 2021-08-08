namespace Bakery.Models.BakedFoods
{
    public class Bread : BakedFood
    {
        private const int InitialBradPortion = 200;
        public Bread(string name, decimal price) 
            : base(name, InitialBradPortion, price)
        {
        }
    }
}
