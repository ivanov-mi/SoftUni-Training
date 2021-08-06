class City
{
    public City(string cityName, int population, int gold)
    {
        Name = cityName;
        Population = population;
        Gold = gold;
    }

    public string Name { get; set; }
    public int Population { get; set; }
    public int Gold { get; set; }
}