using Model = IS_Project.Domain.Entities;
using MediatR;

namespace IS_Project.Application.UseCases.ProjectTask.Queries.GetProjectTask;

public record GetProjectTaskQuery(Guid Id) : IRequest<Model.ProjectTask>;