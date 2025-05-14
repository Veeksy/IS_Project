using FluentValidation;

namespace IS_Project.Application.UseCases.Project.Queries.GetProject;

public class GetProjectQueryValidator : AbstractValidator<GetProjectQuery>
{
    public GetProjectQueryValidator() 
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id не должен быть пустым")
            .NotNull()
            .WithMessage("Id не должен быть пустым");
    }
}