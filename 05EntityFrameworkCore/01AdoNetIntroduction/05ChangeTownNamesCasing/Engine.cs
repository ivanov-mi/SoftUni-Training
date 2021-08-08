namespace ChangeTownNamesCasing
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Data.SqlClient;

    public class Engine
    {
        public void Run()
        {
            var countryName = Console.ReadLine();

            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                var rowsAffected = GetAffectedRows(connection, countryName);

                if (rowsAffected <= 0)
                {
                    Console.WriteLine("No town names were affected.");
                    Environment.Exit(0);
                }

                Console.WriteLine($"{rowsAffected} town names were affected.");

                var townNames = GetTownsByName(connection, countryName);

                Console.WriteLine($"[{string.Join(", ", townNames)}]");
            }
        }

        private static List<string> GetTownsByName(SqlConnection connection, string countryName)
        {
            var townNames = new List<string>();

            var namesQuery = Queries.SelectTownsByCountry;

            var command = new SqlCommand(namesQuery, connection);
            
            command.Parameters.AddWithValue("@countryName", countryName);

            using (var dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    string town = (string)dataReader[0];

                    townNames.Add(town);
                }
            }
            
            return townNames;
        }

        private static int GetAffectedRows(SqlConnection connection, string countryName)
        {
            var updateQuery = Queries.ChangeNamesToUpper;

            var command = new SqlCommand(updateQuery, connection);
            command.Parameters.AddWithValue("@countryName", countryName);

            return command.ExecuteNonQuery();
        }
    }
}
