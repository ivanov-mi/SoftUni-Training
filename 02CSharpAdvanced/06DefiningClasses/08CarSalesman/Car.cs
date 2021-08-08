using System;
using System.Text;

namespace _08.CarSalesman
{
    public class Car
    {
        public Car(string carModel, Engine engine)
        {
            this.CarModel = carModel;
            this.Engine = engine;
        }
        public Car(string carModel, Engine engine, int weight) : this(carModel, engine)
        {
            this.Weight = weight;
        }
        public Car(string carModel, Engine engine, string color) : this(carModel, engine)
        {
            this.Color = color;
        }
        public Car(string carModel, Engine engine, int weight, string color) : this (carModel, engine, weight)
        {
            this.Color = color;
        }

        public string CarModel { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append($"{CarModel}:{Environment.NewLine}");
            sb.Append($"  {Engine.EngineModel}:{Environment.NewLine}");
            sb.Append($"    Power: {Engine.Power}{Environment.NewLine}");
            if (Engine.Displacement == 0)
            {
                sb.Append($"    Displacement: n/a{Environment.NewLine}");
            }
            else
            {
                sb.Append($"    Displacement: {Engine.Displacement}{Environment.NewLine}");
            }

            sb.Append($"    Efficiency: {(Engine.Efficiency ?? "n/a")}{Environment.NewLine}");
            if (Weight == 0)
            {
                sb.Append($"  Weight: n/a{Environment.NewLine}");
            }
            else
            {
                sb.Append($"  Weight: {Weight}{Environment.NewLine}");
            }

            sb.Append($"  Color: {(Color ?? "n/a")}");

            return sb.ToString();
        }
    }
}
