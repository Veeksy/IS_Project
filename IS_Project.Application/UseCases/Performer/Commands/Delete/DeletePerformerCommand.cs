using MediatR;

namespace IS_Project.Application.UseCases.Performer.Commands.Delete;

public record DeletePerformerCommand(Guid Id) : IRequest;
