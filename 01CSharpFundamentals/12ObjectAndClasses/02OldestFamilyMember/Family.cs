using System.Collections.Generic;
using System.Linq;

public class Family
{
    public Family()
    {
        this.MemberList = new List<Person>();
    }

    public List<Person> MemberList { get; set; }

    public void AddMember(Person familyMember)
    {
        MemberList.Add(familyMember);
    }

    public Person GetOldestMember() => MemberList
        .OrderByDescending(x => x.Age)
        .FirstOrDefault();
}