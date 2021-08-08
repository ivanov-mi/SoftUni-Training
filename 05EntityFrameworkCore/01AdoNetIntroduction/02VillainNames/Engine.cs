namespace VillainNames
{
    using System;
    using Microsoft.Data.SqlClient;

    public class Engine
    {
        public void Run()
        {
            using (var dbConnection = new SqlConnection(Configuration.ConnectionString))
            {
                dbConnection.Open();

                var selectQuery = Queries.selectVilainsNames;

                var command = new SqlCommand(selectQuery, dbConnection);

                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        var villainName = reader["VillainName"]?.ToString();
                        var minionsCount = reader["NumberOfMinions"]?.ToString();

                        Console.WriteLine($"{villainName} - {minionsCount}");
                    }
                }
            }
        }
    }
}