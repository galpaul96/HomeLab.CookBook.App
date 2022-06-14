using System.Net;
using System.Runtime.Serialization;

namespace HomeLab.Ecosystem.Exceptions
{
    [Serializable]
    internal class NotFoundRestRequestException : RestRequestException
    {
        public NotFoundRestRequestException() : base(HttpStatusCode.NotFound)
        {
        }

        public NotFoundRestRequestException(string message)
            : base(message)
        {
        }

        public NotFoundRestRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected NotFoundRestRequestException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public NotFoundRestRequestException(Exception innerException)
            : base(innerException.Message, innerException)
        {
        }
    }
}
