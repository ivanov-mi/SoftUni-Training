namespace MilitaryElite.Contracts
{
    using Enums;
    public interface IMission
    {
        public string Codename { get; }
        public MissionState State { get; }

        public void CompleteMission();
    }
}
