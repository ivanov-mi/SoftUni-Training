namespace InitialSetup
{
    using Microsoft.Data.SqlClient;

    public class Engine
    {
        public void Run()
        {
            // Create database
            using (var connection = new SqlConnection(Configuration.DefaultConectionString))
            {
                connection.Open();

                var createDbQuery = Queries.createDB;

                ExecNonQuery(createDbQuery, connection);
            }

            // Create tables and insert data
            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                var createStatements = Queries.createTables;
                ExecNonQuery(createStatements, connection);

                var insertStatements = Queries.insertData;
                ExecNonQuery(insertStatements, connection);
            }
        }
        private static void ExecNonQuery(string cmdText, SqlConnection connection)
        {
            var command = new SqlCommand(cmdText, connection);
            command.ExecuteNonQuery();
        }
    }
}