using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital
{
    public class Room
    {
        private readonly int RoomCapacity = 3;

        public Room()
        {
            this.Patients = new List<Patient>();
        }

        public List<Patient> Patients { get; set; }

        public bool hasFreeBed => this.Patients.Count < this.RoomCapacity;

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var patient in this.Patients.OrderBy(p => p.Name))
            {
                sb.AppendLine($"{patient.Name}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
