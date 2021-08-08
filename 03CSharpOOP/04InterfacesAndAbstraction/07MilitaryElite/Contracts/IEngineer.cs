namespace MilitaryElite.Contracts
{
    using System.Collections.Generic;

    public interface IEngineer : ISpecializedSoldiers
    {
        public ICollection<IRepair> Repairs { get; }
    }
}
