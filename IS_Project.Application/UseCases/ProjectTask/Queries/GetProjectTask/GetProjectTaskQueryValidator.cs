using FluentValidation;

namespace IS_Project.Application.UseCases.ProjectTask.Queries.GetProjectTask;

public class GetProjectTaskQueryValidator : AbstractValidator<GetProjectTaskQuery>
{
    public GetProjectTaskQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Требуется указать Id")
            .NotNull()
            .WithMessage("Требуется указать Id");
    }
}