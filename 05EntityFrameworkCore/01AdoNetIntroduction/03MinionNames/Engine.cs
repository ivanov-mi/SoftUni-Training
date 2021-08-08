namespace MinionNames
{
    using System;
    using System.Text;
    using Microsoft.Data.SqlClient;

    public class Engine
    {
        public void Run()
        {
            var villainId = int.Parse(Console.ReadLine());

            using (var dbConnection = new SqlConnection(Configuration.ConnectionString))
            {
                dbConnection.Open();

                var getVillainNameCmd = new SqlCommand(Queries.selectVilainById, dbConnection);

                getVillainNameCmd.Parameters.AddWithValue("@VillainId", villainId);

                var villainName = getVillainNameCmd.ExecuteScalar()?.ToString();

                if (villainName == null)
                {
                    Console.WriteLine($"No villain with ID {villainId} exists in the database");
                    return;
                }

                var minionsList = GetMinionsList(villainId, dbConnection);

                Console.WriteLine($"Villain: {villainName}\n" +
                    $"{minionsList}");
            }
        }

        private static string GetMinionsList(int villainId, SqlConnection dbConnection)
        {
            var sb = new StringBuilder();

            var getMinionsCmd = new SqlCommand(Queries.selectMinionsByVillianId, dbConnection);

            getMinionsCmd.Parameters.AddWithValue("@VillainId", villainId);

            using (var reader = getMinionsCmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    sb.AppendLine("(no minions)");
                }
                else
                {
                    int counter = 0;

                    while (reader.Read())
                    {
                        counter++;
                        var minionName = reader[0]?.ToString();
                        var minionAge = reader[1]?.ToString();

                        sb.AppendLine($"{counter}. {minionName} {minionAge}");
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}