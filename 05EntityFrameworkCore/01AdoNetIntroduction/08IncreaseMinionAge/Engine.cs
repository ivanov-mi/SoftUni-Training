namespace IncreaseMinionAge
{
    using System;
    using System.Linq;
    using Microsoft.Data.SqlClient;

    class Engine
    {
        public void Run()
        {
            var minionIds = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                foreach (var id in minionIds)
                {
                    UpdateMinionsById(connection, id);
                }

                PrintAllMinions(connection);
            }
        }

        private static void PrintAllMinions(SqlConnection connection)
        {
            var command = new SqlCommand(Queries.SelectNameAndAge, connection);
            using (var dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    var minionName = dataReader[0]?.ToString();
                    var minionAge = Convert.ToInt32(dataReader[1]);

                    Console.WriteLine($"{minionName} {minionAge}");
                }
            }
        }

        private static void UpdateMinionsById(SqlConnection connection, int id)
        {
            var command = new SqlCommand(Queries.UpdateMinionById, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }
    }
}
