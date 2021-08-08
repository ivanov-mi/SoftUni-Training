namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const int MinHorsePower = 250;
        private const int MaxHorsePower = 450;
        private const double CubicCentimetersData = 3000;
        public SportsCar(string model, int horsePower)
            : base(model, horsePower, CubicCentimetersData, MinHorsePower, MaxHorsePower)
        {
        }
    }
}
