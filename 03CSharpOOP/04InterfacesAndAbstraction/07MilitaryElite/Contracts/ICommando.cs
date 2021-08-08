namespace MilitaryElite.Contracts
{
    using System.Collections.Generic;

    public interface ICommando : ISpecializedSoldiers
    {
        public ICollection<IMission> Missions { get; }
    }
}
