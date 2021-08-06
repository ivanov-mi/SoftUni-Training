class Product
{
    public Product(string productName, double cost)
    {
        this.Name = productName;
        this.Cost = cost;
    }

    public string Name { get; set; }
    public double Cost { get; set; }
}