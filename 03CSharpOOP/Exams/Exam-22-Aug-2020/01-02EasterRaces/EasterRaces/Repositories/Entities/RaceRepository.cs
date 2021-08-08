namespace EasterRaces.Repositories.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using EasterRaces.Models.Races.Contracts;
    using EasterRaces.Repositories.Contracts;

    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> races;

        public RaceRepository()
        {
            this.races = new List<IRace>();
        }
        public void Add(IRace name)
            => this.races.Add(name);

        public IReadOnlyCollection<IRace> GetAll()
            => this.races.AsReadOnly();

        public IRace GetByName(string name)
            => this.races.FirstOrDefault(x => x.Name == name);

        public bool Remove(IRace name)
            => this.races.Remove(name);
    }
}
