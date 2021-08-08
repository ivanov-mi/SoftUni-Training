namespace MilitaryElite.Models
{
    using Contracts;
    using Enums;

    public class Mission : IMission
    {
        public Mission(string codename, MissionState state)
        {
            this.Codename = codename;
            this.State = state;
        }

        public string Codename { get; }

        public MissionState State { get; private set; }

        public void CompleteMission()
        {
            this.State = MissionState.Finished;
        }
        public override string ToString()
        {
            return $"Code Name: {this.Codename} State: {this.State}";
        }
    }
}
