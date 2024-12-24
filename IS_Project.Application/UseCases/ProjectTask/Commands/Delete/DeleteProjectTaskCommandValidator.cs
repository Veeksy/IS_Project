using FluentValidation;

namespace IS_Project.Application.UseCases.ProjectTask.Commands.Delete;

public class DeleteProjectTaskCommandValidator : AbstractValidator<DeleteProjectTaskCommand>
{
    public DeleteProjectTaskCommandValidator()
    {
        RuleFor(x=>x.Id)
            .NotEmpty()
            .WithMessage("Id не должен быть пустым")
            .NotNull()
            .WithMessage("Id не должен быть пустым");
    }
}
