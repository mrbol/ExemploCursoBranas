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
using Domain.Entity;
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

        public async Task<T> QuerySingle<T>(string statement)
        {         
            if(_connection.State == ConnectionState.Closed) await _connection.OpenAsync();
            var item = await _connection.QuerySingleAsync<T>(statement);
            if (item == null)
            {
                throw new AppExceptionNotFound("The searched item was not found. check the entered value.");
            }
            return item;
        }
        public async Task<IEnumerable<T>> Query<T>(string statement) {
            if (_connection.State == ConnectionState.Closed) await _connection.OpenAsync();
            var list = await _connection.QueryAsync<T>(statement);
            if (!list.Any())
            {
                throw new AppExceptionNotFound("no results found");
            }
            return list;
        }


        public async Task<T> ExecuteScalar<T>(string statement,object? param)
        {
            if (_connection.State == ConnectionState.Closed) await _connection.OpenAsync();
            return await _connection.ExecuteScalarAsync<T>(statement,param);
        }

        public async Task<int> Execute(string statement,object? param)
        {
            if (_connection.State == ConnectionState.Closed) await _connection.OpenAsync();
            return await _connection.ExecuteAsync(statement,param);
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
