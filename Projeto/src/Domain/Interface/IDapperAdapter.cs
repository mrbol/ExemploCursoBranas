using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IDapperAdapter : IDisposable
    {
        Task<T> Query<T>(string statement);
        Task CloseAsync();
    }
}
