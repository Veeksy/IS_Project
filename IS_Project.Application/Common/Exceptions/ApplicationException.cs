using System.Net;

namespace IS_Project.Application.Common.Exceptions
{
    public abstract class ApplicationException(HttpStatusCode statusCode, string message) : Exception(message)
    {
        public HttpStatusCode ApplicationErrorCode { get; } = statusCode;
    }
}
