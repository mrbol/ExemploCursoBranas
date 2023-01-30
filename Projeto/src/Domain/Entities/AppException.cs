using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AppException : Exception
    {
        public AppException() : base() { }

        public AppException(string message) : base(message) { }

        public AppException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }

    public class AppExceptionNotFound : AppException
    {
        public AppExceptionNotFound() : base() { }
        public AppExceptionNotFound(string message) : base(message) { }
    }

    public class AppExceptionBadRequest : AppException
    {
        public AppExceptionBadRequest() : base() { }
        public AppExceptionBadRequest(string message) : base(message) { }
    }
}
