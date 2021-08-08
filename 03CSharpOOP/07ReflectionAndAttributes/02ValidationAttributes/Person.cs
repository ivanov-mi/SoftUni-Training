namespace ValidationAttributes
{
    using Attributes;

    public class Person
    {
        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }

        [MyRequired]
        public string FullName { get; private set; }

        [MyRange(18, 65)]
        public int Age { get; private set; }
    }
}
