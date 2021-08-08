namespace VillainNames
{
    public class Queries
    {
        public const string selectVilainsNames =
			@"SELECT v.Name AS [VillainName], COUNT(mv.VillainId) AS [NumberOfMinions]
				FROM Villains AS v
				JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
				GROUP BY v.Id, v.Name
				HAVING COUNT(mv.VillainId) > 3
				ORDER BY COUNT(mv.VillainId) DESC";
    }
}
