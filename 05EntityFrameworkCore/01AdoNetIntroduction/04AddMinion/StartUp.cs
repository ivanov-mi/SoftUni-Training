namespace AddMinion
{
    using System;
    using Microsoft.Data.SqlClient;

    public class StartUp
    {
        static void Main()
        {
            var engine = new Engine();
            engine.Run();
        }
    }
}
