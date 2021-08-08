namespace _07.RawDAta
{
    public class Car
    {
        public Car(string modelName, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.ModelName = modelName;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tire = tires;
        }

        public string ModelName { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tire { get; set; }
    }
}
