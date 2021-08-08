namespace MilitaryElite.Models
{
    using Contracts;

    public class Repair : IRepair
    {
        public Repair(string partName, int hoursWorker)
        {
            this.PartName = partName;
            this.HoursWorker = hoursWorker;
        }

        public string PartName { get;  }

        public int HoursWorker { get;  }

        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.HoursWorker}";
        }
    }
}
