public class Model
{
    public Model(string modelOfCar, Engine engineProperties, Cargo cargoSpecifications)
    {
        this.ModelOfCar = modelOfCar;
        this.EngineProperties = engineProperties;
        this.CargoSpecifications = cargoSpecifications;
    }

    public string ModelOfCar { get; set; }
    public Engine EngineProperties { get; set; }
    public Cargo CargoSpecifications { get; set; }
}