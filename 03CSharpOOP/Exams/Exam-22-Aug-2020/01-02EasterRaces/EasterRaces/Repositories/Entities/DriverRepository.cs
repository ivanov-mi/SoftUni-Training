namespace EasterRaces.Repositories.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using EasterRaces.Models.Drivers.Contracts;
    using EasterRaces.Repositories.Contracts;

    public class DriverRepository : IRepository<IDriver>
    {
        private readonly List<IDriver> drivers;

        public DriverRepository()
        {
            this.drivers = new List<IDriver>();
        }
        public void Add(IDriver name)
            => this.drivers.Add(name);

        public IReadOnlyCollection<IDriver> GetAll()
            => this.drivers.AsReadOnly();

        public IDriver GetByName(string name)
            => this.drivers.FirstOrDefault(x => x.Name == name);

        public bool Remove(IDriver name)
            => this.drivers.Remove(name);
    }
}
