namespace MinionNames
{
    public class Queries
    {
        public const string selectVilainById = 
            @"SELECT [Name] 
                FROM Villains 
                WHERE Villains.Id = @VillainId";

        public const string selectMinionsByVillianId = 
            @"SELECT m.[Name] , m.Age
                FROM Minions AS m
                JOIN MinionsVillains AS mv ON m.Id = mv.MinionId
                WHERE mv.VillainId = @VillainId
	            ORDER BY m.[Name]";
    }
}
