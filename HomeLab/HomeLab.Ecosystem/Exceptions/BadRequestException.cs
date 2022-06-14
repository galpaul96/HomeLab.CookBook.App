using System.Net;
using System.Runtime.Serialization;

namespace HomeLab.Ecosystem.Exceptions
{
    [Serializable]
    internal class BadRequestException : RestRequestException
    {
        public List<BadRequestError> Errors { get; set; }

        public BadRequestException() : base(HttpStatusCode.BadRequest)
        {
        }

        public BadRequestException(string message)
            : base(message, HttpStatusCode.BadRequest)
        {
        }

        public BadRequestException(string message, Exception innerException)
            : base(message, innerException, HttpStatusCode.BadRequest)
        {
        }

        protected BadRequestException(SerializationInfo info, StreamingContext context)
            : base(info, context, HttpStatusCode.BadRequest)
        {
        }

        public BadRequestException(Exception innerException)
            : base(innerException.Message, innerException, HttpStatusCode.BadRequest)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }

    internal class BadRequestErrorCollection
    {
        public List<BadRequestError> Errors { get; set; }
    }

    internal class BadRequestError
    {
        public string Code { get; set; }
        public string Field { get; set; }
        public string Message { get; set; }
    }
}
