namespace MilitaryElite.Contracts
{
    using Enums;

    public interface ISpecializedSoldiers : IPrivate
    {
        public Corps Corps { get; }
    }
}
