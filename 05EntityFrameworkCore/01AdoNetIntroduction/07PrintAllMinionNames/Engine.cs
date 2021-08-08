namespace PrintAllMinionNames
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Data.SqlClient;

    class Engine
    {
        public void Run()
        {
            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                var minionNames = GetAllMinionNames(connection);

                PrintAllMinionNames(minionNames);
            }
        }

        private static void PrintAllMinionNames(List<string> minionNames)
        {
            if (minionNames.Count > 0)
            {
                for (int i = 0; i < minionNames.Count / 2; i++)
                {
                    Console.WriteLine(minionNames[i]);
                    Console.WriteLine(minionNames[minionNames.Count - 1 - i]);
                }

                if (minionNames.Count % 2 != 0)
                {
                    Console.WriteLine(minionNames[minionNames.Count / 2]);
                }
            }
        }

        private static List<string> GetAllMinionNames(SqlConnection connection)
        {
            var minionNames = new List<string>();

            var selectNameQuery = Queries.SelectMinions;

            var command = new SqlCommand(selectNameQuery, connection);
            
            using (var dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    var name = dataReader[0]?.ToString();

                    minionNames.Add(name);
                }
            }

            return minionNames;
        }
    }
}
