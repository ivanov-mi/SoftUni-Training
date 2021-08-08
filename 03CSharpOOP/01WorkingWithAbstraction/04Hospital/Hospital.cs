using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    public class Hospital
    {
        public Hospital()
        {
            this.Doctors = new List<Doctor>();
            this.Departments = new List<Department>();
        }

        public List<Doctor> Doctors { get; set; }
        public List<Department> Departments { get; set; }

        public void AddDoctor (string firstName, string secondName)
        {
            if (!this.Doctors.Any(doc => doc.FirstName == firstName && doc.SecondName == secondName))
            {
                var doctor = (new Doctor(firstName, secondName));
                this.Doctors.Add(doctor);
            }
        }

        public void AddDepartment(string name)
        {
            if (!this.Departments.Any(dep => dep.Name == name))
            {
                var department = new Department(name);
                this.Departments.Add(department);
            }
        }

        public void AddPatient(string departmentName, string doctorFullName, string patientName)
        {
            var department = this.Departments.FirstOrDefault(dep => dep.Name == departmentName);
            var doctor = this.Doctors.FirstOrDefault(doc => doc.FullName == doctorFullName);

            var patient = new Patient(patientName);

            if (department.AddPartienToRoom(patient))
            {
                doctor.Patients.Add(patient);
            }
        }
    }
}
