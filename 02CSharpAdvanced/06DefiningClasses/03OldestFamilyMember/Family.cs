using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> litsOfPeople;

        public Family()
        {
            this.litsOfPeople = new List<Person>();
        }

        public void AddMember(Person person)
        {
            this.litsOfPeople.Add(person);
        }

        public Person GetOldestMember()
        {
            return litsOfPeople.OrderByDescending(x => x.Age).FirstOrDefault();
        }

    }
}
