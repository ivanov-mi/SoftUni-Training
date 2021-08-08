namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const int MinHorsePower = 400;
        private const int MaxHorsePower = 600;
        private const double CubicCentimetersData = 5000;
        public MuscleCar(string model, int horsePower)
            : base(model, horsePower, CubicCentimetersData, MinHorsePower, MaxHorsePower)
        {
        }
    }
}
