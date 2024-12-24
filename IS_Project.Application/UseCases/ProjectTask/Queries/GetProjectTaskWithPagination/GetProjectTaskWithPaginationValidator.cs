using FluentValidation;

namespace IS_Project.Application.UseCases.ProjectTask.Queries.GetProjectTaskWithPagination;

public class GetProjectTaskWithPaginationValidator : AbstractValidator<GetProjectTaskWithoutPagination>
{
    public GetProjectTaskWithPaginationValidator()
    {
    }
}
