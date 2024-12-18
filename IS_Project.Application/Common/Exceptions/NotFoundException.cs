using System.Net;

namespace IS_Project.Application.Common.Exceptions;

public class NotFoundException(Guid id) : ApplicationException(HttpStatusCode.NotFound, $"Entity with id {id} was not found");
