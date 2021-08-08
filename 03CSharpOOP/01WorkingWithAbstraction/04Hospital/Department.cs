using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital
{
    public class Department
    {
        private readonly int departmentRooms = 20;
        public Department(string name)
        {
            Name = name;
            this.Rooms = new List<Room>();

            CreateRooms(this.departmentRooms);
        }

        public string Name { get; set; }
        public List<Room> Rooms { get; set; }

        public bool AddPartienToRoom(Patient patient)
        {
            var firstRoomWithFreeBed = this.Rooms.FirstOrDefault(r => r.hasFreeBed);

            if (firstRoomWithFreeBed != null)
            {
                firstRoomWithFreeBed.Patients.Add(patient);
                return true;
            }

            return false;
        }
        private void CreateRooms(int departmentRooms)
        {
            for (int i = 0; i < departmentRooms; i++)
            {
                this.Rooms.Add(new Room());
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var room in this.Rooms)
            {
                foreach (var patient in room.Patients)
                {
                    sb.AppendLine(patient.Name);
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
