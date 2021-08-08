using System;
using System.Linq;

namespace Hospital
{
    public class Engine
    {
        private Hospital hospital;

        public Engine()
        {
            this.hospital = new Hospital();
        }
        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] tokens = command.Split();
                var department = tokens[0];
                var firstName = tokens[1];
                var secondName = tokens[2];
                var patientName = tokens[3];
                var doctorFullName = firstName + " " + secondName;

                this.hospital.AddDoctor(firstName, secondName);
                this.hospital.AddDepartment(department);
                this.hospital.AddPatient(department, doctorFullName, patientName);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 1)
                {
                    var departmentName = tokens[0];
                    var department = this.hospital.Departments
                        .FirstOrDefault(d => d.Name == departmentName);

                    if (department != null)
                    {
                        Console.WriteLine(department);
                    }
                }
                else
                {
                    bool isRoom = int.TryParse(tokens[1], out int roomNumber);

                    if (isRoom)
                    {
                        var departmentName = tokens[0];
                        var department = this.hospital.Departments
                            .FirstOrDefault(dep => dep.Name == departmentName);

                        var currentRoom = department.Rooms[roomNumber - 1];

                        if (currentRoom != null)
                        {
                            Console.WriteLine(currentRoom);
                        }
                    }
                    else
                    {
                        string firstName = tokens[0];
                        string secondName = tokens[1];
                        string fullName = firstName + " " + secondName;

                        var currentDoctor = this.hospital.Doctors
                            .FirstOrDefault(doc => doc.FullName == fullName);

                        if (currentDoctor != null)
                        {
                            Console.WriteLine(currentDoctor);
                        }
                    }
                }

                command = Console.ReadLine();
            }
        }
    }
}
