using System.Net;
using System.Runtime.Serialization;

namespace HomeLab.Ecosystem.Exceptions
{
    [Serializable]
    internal class RestRequestException : Exception
    {
        public HttpStatusCode StatusCode { get; protected set; }

        public RestRequestException()
        {
        }

        public RestRequestException(HttpStatusCode statusCode)
            : this(string.Empty, statusCode)
        {
        }

        public RestRequestException(string message)
            : base(message)
        {
        }

        public RestRequestException(string message, HttpStatusCode statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public RestRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public RestRequestException(string message, Exception innerException, HttpStatusCode statusCode)
            : this(message, innerException)
        {
            StatusCode = statusCode;
        }

        protected RestRequestException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public RestRequestException(SerializationInfo info, StreamingContext context, HttpStatusCode statusCode)
            : this(info, context)
        {
            StatusCode = statusCode;
        }

        public RestRequestException(Exception innerException)
            : base(innerException.Message, innerException)
        {
        }
    }
}
