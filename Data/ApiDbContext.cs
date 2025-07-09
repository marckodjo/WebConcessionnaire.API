using Microsoft.Data.SqlClient;
using System.Data;

namespace WebConcessionnaire.API.Data
{
    public class ApiDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        public ApiDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("ApiConnexionString");
        }

        public IDbConnection CreateConnection() => new SqlConnection(connectionString);
        
    }
}
