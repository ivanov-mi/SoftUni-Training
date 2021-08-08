using System;

namespace IteratorsAndComparators
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo(Person otherPerson)
        {
            if (this.name.CompareTo(otherPerson.name) != 0)
            {
                return this.name.CompareTo(otherPerson.name);
            }
            else if (this.age.CompareTo(otherPerson.age) != 0)
            {
                return this.age.CompareTo(otherPerson.age);
            }

            return 0;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.name, this.age);
        }

        public override bool Equals(object obj)
        {
            Person otherPerson = obj as Person;

            if (otherPerson == null)
            {
                return false;
            }

            return this.name == otherPerson.name && this.age == otherPerson.age;
        }

    }
}