using MediatR;

namespace IS_Project.Application.UseCases.ProjectTask.Commands.Delete;

public record DeleteProjectTaskCommand(Guid Id) : IRequest;
