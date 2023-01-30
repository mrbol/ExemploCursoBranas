using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AppException : Exception
    {
        protected int _statusCode = (int)HttpStatusCode.BadRequest;
        protected string _title = "Bad Request";
        protected string _type = "https://www.rfc-editor.org/rfc/rfc7231#section-6.5.1";

        public int StatusCode { get => _statusCode;}
        public string Title { get => _title;}
        public string Type { get => _type;}

        public AppException() : base() {
        }
        public AppException(string message) : base(message) {
        }
        public AppException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }

    public class AppExceptionNotFound : AppException
    {
        public AppExceptionNotFound() : base() {
            _statusCode = (int)HttpStatusCode.NotFound;
            _title = "Not Found";
            _type = "https://www.rfc-editor.org/rfc/rfc7231#section-6.5.4";
        }
        public AppExceptionNotFound(string message) : base(message) {
            _statusCode = (int)HttpStatusCode.NotFound;
            _title = "Not Found";
            _type = "https://www.rfc-editor.org/rfc/rfc7231#section-6.5.4";
        }
    }

    public class AppExceptionBadRequest : AppException
    {
        public AppExceptionBadRequest() : base()
        {
            _statusCode = (int)HttpStatusCode.BadRequest;
            _title = "One or more validation errors occurred";
            _type = "https://www.rfc-editor.org/rfc/rfc7231#section-6.5.1";
        }
        public AppExceptionBadRequest(string message) : base(message)
        {
            _statusCode = (int)HttpStatusCode.BadRequest;
            _title = "One or more validation errors occurred";
            _type = "https://www.rfc-editor.org/rfc/rfc7231#section-6.5.1";
        }
    }
}
