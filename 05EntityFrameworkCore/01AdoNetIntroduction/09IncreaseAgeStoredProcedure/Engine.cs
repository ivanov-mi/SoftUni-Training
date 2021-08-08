namespace IncreaseAgeStoredProcedure
{
    using System;
    using Microsoft.Data.SqlClient;

    class Engine
    {
        public void Run()
        {
            var id = int.Parse(Console.ReadLine());

            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                CreateProcedure(connection);

                ExecuteProcedure(connection, id);
                PrintMinionById(connection, id);
            }
        }

        private static void PrintMinionById(SqlConnection connection, int id)
        {
            var command = new SqlCommand(Queries.SelectMinionById, connection);
            command.Parameters.AddWithValue("@Id", id);

            using (var dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    var minionName = dataReader[0]?.ToString();
                    var minionAge = Convert.ToInt32(dataReader[1]);

                    Console.WriteLine($"{minionName} – {minionAge} years old");
                }
            }
        }

        private static void ExecuteProcedure(SqlConnection connection, int id)
        {
            using var command = new SqlCommand(Queries.ExecuteProcedure, connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        private static void CreateProcedure(SqlConnection connection)
        {
            using var command = new SqlCommand(Queries.CreateGetOlderProcedure, connection);
            command.ExecuteNonQuery();
        }
    }
}
