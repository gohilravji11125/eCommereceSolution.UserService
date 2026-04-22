using eCommerece.Application.Interfaces;
using eCommerece.Infrastructure.Options;
using Microsoft.Extensions.Options;
using Npgsql;
using System.Data;

namespace eCommerece.Infrastructure.Services.DBConnectionService
{
    public class DBConnectionFactory(IOptions<ConnectionOptions> options) : IDBConnectionFactory
    {
        private readonly ConnectionOptions _options = options.Value;

        public IDbConnection GetDBConnection()
        {
            return new NpgsqlConnection(_options.DefaultConnection);
        }
    }
}
