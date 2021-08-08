namespace P01_HospitalDatabase
{

    using Microsoft.EntityFrameworkCore;

    using Data;

    public class StartUp
    {
        static void Main()
        {
            using var context = new HospitalContext();
            context.Database.Migrate();
        }
    }
}
