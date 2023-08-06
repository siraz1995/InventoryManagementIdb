using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DataAccess: IDataAccess
    {
        private readonly IConfiguration _config;
        public DataAccess(IConfiguration config)
        {
            _config = config;
        }  
        
        // this method will retuarn a list of type T
        public async Task<IEnumerable<T>> Query<T, P>(string query, P parameters, string connectionId = "default")
        {
            using IDbConnection connection =new SqlConnection(_config.GetConnectionString(connectionId));
            return await connection.QueryAsync<T>(query, parameters);
        }

        //This method will not return anything
        public async Task Command<P>(string query, P parameters, string connectionId = "default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
            await connection.ExecuteAsync(query, parameters);
        }


        // this method will retuarn a list of type T
        public async Task<IEnumerable<T>> QueryAsync<T, P>(string query, P parameters, string connectionId = "purchaseOrder")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
            return await connection.QueryAsync<T>(query, parameters);
        }

        //This method will not return anything
        public async Task CommandAsync<P>(string query, P parameters, string connectionId = "purchaseOrder")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
