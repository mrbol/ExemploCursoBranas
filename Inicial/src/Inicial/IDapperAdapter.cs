using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicial
{
    public interface IDapperAdapter : IDisposable
    {
        Task<T> Query<T>(string statement);
        Task CloseAsync();
    }
}
