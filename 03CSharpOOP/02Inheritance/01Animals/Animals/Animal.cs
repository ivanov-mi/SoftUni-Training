using System;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;
        public enum GenderOptions { Male, Female };

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name 
        { 
            get => name;
            set
            {
                name = value ?? throw new ArgumentException("Invalid input!");
            }
        }
        public int Age 
        { 
            get => age;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;
            } 
        }
        
        public string Gender
        {
            get => this.gender;
            set
            { 
                if (Enum.IsDefined(typeof(GenderOptions), value) == false)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.gender = value; 
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.AppendLine(this.ProduceSound());

            return sb.ToString().TrimEnd();
        }

    }
}
