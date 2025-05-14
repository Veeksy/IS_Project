using FluentValidation;

namespace IS_Project.Application.UseCases.ProjectTask.Commands.Create;

public class CreateProjectTaskCommandValidator : AbstractValidator<CreateProjectTaskCommand>
{
    public CreateProjectTaskCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Наименование не может быть пустым")
            .NotNull()
            .WithMessage("Наименование не может быть пустым");

        RuleFor(x => x.Description)
            .MaximumLength(1500)
            .WithMessage("Описание не должно превышать 1500 символов");

        RuleFor(x => x.SpentTime)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.EstablishedTime)
            .NotNull()
            .NotEmpty();

        RuleFor(x=>x.ProjectId).NotNull()
            .WithMessage("Id проекта не должно быть пустым")
            .NotEmpty()
            .WithMessage("Id проекта не должно быть пустым");

        RuleFor(x => x.Priority)
            .NotNull()
            .NotEmpty();
    }
}