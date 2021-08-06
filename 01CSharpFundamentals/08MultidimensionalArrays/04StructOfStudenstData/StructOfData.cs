using System;

class StructOfData
{
    static void Main()
    {
        //04. Make a struct of students each having an ID, Name, Age, Gender and Score out of 100. 
        //    Create an Array of 10 students and sort them by:
        //    ID, Name, Name(reverse), Age, Score, Name Length and(first by Gender and then by Name).
        //    YOU ARE NOT ALLOWED TO USE LINQ

        Student[] arrayOfStudents = 
        {
            new Student("13421", "Pesho", 23, "Male", 93 ),
            new Student("14421", "Ivan", 21, "Male", 54 ),
            new Student("14521", "Mariq", 22, "Female", 96 ),
            new Student("14461", "Gosho", 23, "Male", 87 ),
            new Student("24521", "Mira", 27, "Female", 93 ),
            new Student("12321", "Tosho", 19, "Male", 79 ),
            new Student("75221", "Ana", 31, "Female", 88 ),
            new Student("13400", "Tuncho", 23, "Male", 44 ),
            new Student("63421", "Miro", 20, "Male", 100 ),
            new Student("63432", "Qna", 23, "Female", 64 ),
        };

        Console.WriteLine("Sort students list by ID:");
        Array.Sort(arrayOfStudents, (x,y) => x.ID.CompareTo(y.ID));
        PrintStudentsArray(arrayOfStudents);
        
        Console.WriteLine("Sort students list by Name:");
        Array.Sort(arrayOfStudents, (x, y) => x.Name.CompareTo(y.Name));
        PrintStudentsArray(arrayOfStudents);
        
        Console.WriteLine("Sort students list by Name(reversed):");
        Array.Sort(arrayOfStudents, (x, y) => y.Name.CompareTo(x.Name));
        PrintStudentsArray(arrayOfStudents);
        
        Console.WriteLine("Sort students list by Age:");
        Array.Sort(arrayOfStudents, (x, y) => x.Age.CompareTo(y.Age));
        PrintStudentsArray(arrayOfStudents);
        
        Console.WriteLine("Sort students list by Score:");
        Array.Sort(arrayOfStudents, (x, y) => x.Score.CompareTo(y.Score));
        PrintStudentsArray(arrayOfStudents);
        
        Console.WriteLine("Sort students list by Name:");
        Array.Sort(arrayOfStudents, (x, y) => x.Name.Length.CompareTo(y.Name.Length));
        PrintStudentsArray(arrayOfStudents);

        Console.WriteLine("Sort students list by Gender and then by Name:");
        Array.Sort(arrayOfStudents, (x, y) => 
        {
            int ret = String.Compare(x.Gender, y.Gender);
            return ret != 0 ? ret : x.Name.CompareTo(y.Name);
        });
        PrintStudentsArray(arrayOfStudents);
    }

    private static void PrintStudentsArray(Student[] arrayOfStudents)
    {
        Console.WriteLine(new string('-', 50));

        foreach (var student in arrayOfStudents)
        {
            Console.WriteLine(student.ToString());
        }

        Console.WriteLine();
    }

    struct Student
    {
        public string ID;
        public string Name;
        public int Age;
        public string Gender;
        public int Score;

        public Student(string id, string name, int age, string gender, int score)
        {
            this.ID = id;
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
            this.Score = score;
        }

        public override string ToString() => "ID: " + this.ID + " Name: " + this.Name + 
            " Age: " + this.Age + " Gender: " + this.Gender + " Score: " + this.Score;
    }
}