using FluentValidation;

namespace IS_Project.Application.UseCases.Project.Commands.Delete;

public class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
{
    public DeleteProjectCommandValidator()
    {
        RuleFor(x=>x.Id)
            .NotEmpty()
            .WithMessage("Id не должен быть пустым")
            .NotNull()
            .WithMessage("Id не должен быть пустым");
    }
}
