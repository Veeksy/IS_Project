using FluentValidation;

namespace IS_Project.Application.UseCases.Project.Commands.Create;

public class CreateProjectCommandValidator: AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(x=>x.Name)
            .NotEmpty()
            .WithMessage("Имя обязательно")
            .NotNull()
            .WithMessage("Имя обязательно")
            .MaximumLength(150)
            .WithMessage("Максимальная длина 150 символов");

        RuleFor(x=>x.Description)
            .MaximumLength(500)
            .WithMessage("Максимальная длина 500 символов");
    }
}
