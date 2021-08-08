using System.Collections.Generic;

public class VLogger
{
    public VLogger(string name)
    {
        Name = name;
        Followers = new SortedSet<string>();
        Following = new HashSet<string>();
    }

    public string Name { get; set; }
    public SortedSet<string> Followers { get; set; }
    public HashSet<string> Following { get; set; }

    public void AddFollower(string follower)
    {
        if (follower != Name)
        {
            Followers.Add(follower);
        }
    }

    public void Follow(string follow)
    {
        if (follow != Name)
        {
            Following.Add(follow);
        }
    }
}