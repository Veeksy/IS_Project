using FluentValidation;

namespace IS_Project.Application.UseCases.Project.Commands.Update;

public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
{
    public UpdateProjectCommandValidator()
    {
        RuleFor(x=>x.Id)
            .NotEmpty()
            .WithMessage("Id не может быть пустым")
            .NotNull()
            .WithMessage("Id не может быть пустым");

        RuleFor(x => x.ProjectName)
            .NotEmpty()
            .WithMessage("Название проекта является обязательным")
            .NotNull()
            .WithMessage("Название проекта является обязательным");
    }
}
