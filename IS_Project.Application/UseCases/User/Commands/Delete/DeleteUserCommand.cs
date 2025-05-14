using MediatR;

namespace IS_Project.Application.UseCases.User.Commands.Delete;

public record DeleteUserCommand(Guid Id) : IRequest; 
