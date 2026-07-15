using Microsoft.Data.SqlClient;

namespace Teste.ScoreAPI.Infrastructure.Data
{
    public class ConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection Create()
        {
            return new SqlConnection(
                _configuration.GetConnectionString("Connection"));
        }
    }
}
