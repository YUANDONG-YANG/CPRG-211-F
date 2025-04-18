using Npgsql;

namespace EmployeeManager.Services
{
    public abstract class BaseDbAccessor
    {
        protected NpgsqlConnection connection;

        protected BaseDbAccessor()
        {
            string dbHost = "localhost";
            string dbUser = "admin";
            string dbPassword = "admin";
            string dbName = "employee_management";
            int dbPort = 5432;

            var connectionString = $"Host={dbHost};Port={dbPort};Username={dbUser};Password={dbPassword};Database={dbName}";
            connection = new NpgsqlConnection(connectionString);
        }

        protected void OpenConnection()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }

        protected void CloseConnection()
        {
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
    }
}