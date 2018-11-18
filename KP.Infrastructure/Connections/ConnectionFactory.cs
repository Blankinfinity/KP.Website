using System;
using System.Data;
using System.Data.SqlClient;

namespace KP.Infrastructure.Connections
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;

        public ConnectionFactory(string connectionString)
        {
            // Must use a guard clause to ensure something is injected
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(nameof(connectionString), "Connection expects constructor injection for connectionString param.");

            // We have a value by now so assign it
            _connectionString = connectionString;
        }

        public IDbConnection Get()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
