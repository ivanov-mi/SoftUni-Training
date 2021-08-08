using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;
        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>(capacity);
        }

        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int Count => this.roster.Count;

        public void AddPlayer(Player player)
        {
            if (this.roster.Count < this.Capacity)
            {
                this.roster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            var playerToRemove = this.roster.Where(x => x.Name == name).FirstOrDefault();

            if (playerToRemove == null)
            {
                return false;
            }

            roster.Remove(playerToRemove);

            return true;
        }
        public void PromotePlayer(string name)
        {
            var playerToPromote = this.roster.Where(x => x.Name == name).FirstOrDefault();

            playerToPromote.Rank = "Member";
        }
        public void DemotePlayer(string name)
        {
            var playerToDemote = this.roster.Where(x => x.Name == name).FirstOrDefault();

            playerToDemote.Rank = "Trial";
        }
        public Player[] KickPlayersByClass(string @class)
        {
            var kickedPlayersByClass = this.roster.Where(x => x.Class == @class).ToArray();
            this.roster.RemoveAll(x => x.Class == @class);

            return kickedPlayersByClass;
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (var player in roster)
            {
                sb.AppendLine($"{player}");
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }
    }
}
