using Model = IS_Project.Domain.Entities;
using MediatR;

namespace IS_Project.Application.UseCases.Project.Queries.GetProject;

public record GetProjectQuery(Guid Id) : IRequest<Model.Project>;
