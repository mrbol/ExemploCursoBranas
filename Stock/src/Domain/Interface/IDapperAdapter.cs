using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IDapperAdapter : IDisposable
    {
        Task<T> QuerySingle<T>(string statement);
        Task<IEnumerable<T>> Query<T>(string statement);
        Task<T> ExecuteScalar<T>(string statement,object? param=null);
        Task<int> Execute(string statement, object? param = null);
        Task CloseAsync();
    }
}
