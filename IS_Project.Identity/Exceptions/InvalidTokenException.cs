using System.Net;

namespace IS_Project.Identity.Exceptions;

public class InvalidTokenException(HttpStatusCode statusCode, string? message) : Exception(message)
{
    public HttpStatusCode ApplicationErrorCode { get; } = statusCode;
}
