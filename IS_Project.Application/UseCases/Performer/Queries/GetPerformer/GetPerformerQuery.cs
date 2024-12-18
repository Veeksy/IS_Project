using Model = IS_Project.Domain.Entities;
using MediatR;

namespace IS_Project.Application.UseCases.Performer.Queries.GetPerformer;

public record GetPerformerQuery(Guid Id) : IRequest<Model.Performer>;
