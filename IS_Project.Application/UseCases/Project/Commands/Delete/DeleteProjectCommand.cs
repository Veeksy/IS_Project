using MediatR;

namespace IS_Project.Application.UseCases.Project.Commands.Delete;

public record DeleteProjectCommand(Guid Id) : IRequest;
