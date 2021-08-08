namespace ClassroomProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            this.Count = 0;
            this.Capacity = capacity;
            this.students = new List<Student>(capacity);
        }

        public int Count { get; private set; }
        public int Capacity { get; private set; }

        public string RegisterStudent(Student student)
        {
            if (this.Count >= this.Capacity)
            {
                 return "No seats in the classroom";
            }

            this.students.Add(student);
            this.Count++;

            return ($"Added student {student.FirstName} {student.LastName}");
        }

        public string DismissStudent(string firstName, string lastName)
        {
            var student = GetStudent(firstName, lastName);

            if (student == null)
            {
                return "Student not found";
            }

            this.students.Remove(student);
            this.Count--;

            return $"Dismissed student {firstName} {lastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            var subjectEnrolled = students.Where(x => x.Subject == subject);

            if (subjectEnrolled.Any() == false)
            {
                return "No students enrolled for the subject";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");

            foreach (var student in subjectEnrolled)
            {
                sb.AppendLine($"{student.FirstName} {student.LastName}");
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public int GetStudentsCount()
        {
            return this.Count;
        }
        public Student GetStudent(string firstName, string lastName)
        {
            return this.students
                .Where(x => x.FirstName == firstName)
                .Where(x => x.LastName == lastName)
                .FirstOrDefault();
        }
    }
}