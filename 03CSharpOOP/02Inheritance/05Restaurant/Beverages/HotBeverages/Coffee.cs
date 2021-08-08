namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double CoffeeMillilitres = 50;
        private const decimal CoffeePrice = 3.50M;
        public Coffee(string name, double caffeine) 
            : base(name, CoffeePrice, CoffeeMillilitres)
        {
            this.Caffeine = caffeine;
        }
        public double Caffeine { get; set; }
    }
}