using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using Domain.Entities;
using Domain.Interface;


namespace Infra.Persistence
{
    public class DapperAdapter : IDapperAdapter
    {
        private SqlConnection _connection;
        private readonly IConfiguration _configuration;
        public DapperAdapter(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));            
        }

        public async Task<T> Query<T>(string statement)
        {
            T? item;
            if(_connection.State == ConnectionState.Closed) await _connection.OpenAsync();
            IEnumerable<T> items = await _connection.QueryAsync<T>(statement);
            item = (items.Any()) ? items.FirstOrDefault() : default;
            if (item == null)
            {
                throw new AppExceptionNotFound("The searched item was not found. check the entered value.");
            }
            return item;
        }

        public async Task CloseAsync()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                await _connection.CloseAsync();
            }
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
