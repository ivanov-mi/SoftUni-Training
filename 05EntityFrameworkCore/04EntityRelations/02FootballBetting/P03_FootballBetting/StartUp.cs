namespace P03_FootballBetting
{
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        static void Main()
        {
            using var context = new FootballBettingContext();
            context.Database.Migrate();
        }
    }
}
