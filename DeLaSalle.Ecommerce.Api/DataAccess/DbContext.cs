using DeLaSalle.Ecommerce.Api.DataAccess.Interfaces;
using System.Data.Common;
using MySqlConnector;

namespace DeLaSalle.Ecommerce.Api.DataAccess
{
    public class DbContext : IDbContext
    {
        private readonly string _connectionString = "server=localhost;user=root;database=Ecommerce;port=3306";
        MySqlConnection _connection;
        public DbConnection Connection
        {
            get
            {

                if (_connection == null)
                {
                    _connection = new MySqlConnection(_connectionString);
                }
                return _connection;
            }
        }
    }
}