using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Stx.Shared.Api.ApiException
{
	[Serializable]
	public class StxHttpResponseException: Exception
	{
        public string PublicMessage { get; }
        public HttpStatusCode StatusCode { get; }

        //public StxException() { }

        //public StxException(string message)
        //    : base(message) { }

        public StxHttpResponseException(string message, Exception inner)
            : base(message, inner) { }

        public StxHttpResponseException(Exception exception, string publicMessage, HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError)
            : this(publicMessage, exception)
        {
            PublicMessage = publicMessage;
            StatusCode = httpStatusCode;
        }

        public StxHttpResponseException(string publicMessage, HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError)
           : this(publicMessage, null)
        {
            PublicMessage = publicMessage;
            StatusCode = httpStatusCode;
        }
    }
}
