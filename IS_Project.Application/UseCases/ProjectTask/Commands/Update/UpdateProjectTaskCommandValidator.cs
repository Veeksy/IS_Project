using FluentValidation;

namespace IS_Project.Application.UseCases.ProjectTask.Commands.Update;

public class UpdateProjectTaskCommandValidator : AbstractValidator<UpdateProjectTaskCommand>
{
    public UpdateProjectTaskCommandValidator()
    {
        RuleFor(x=>x.Name)
            .NotEmpty()
            .WithMessage("Наименование не может быть пустым")
            .NotNull()
            .WithMessage("Наименование не может быть пустым");

        RuleFor(x => x.Description)
            .MaximumLength(1500)
            .WithMessage("Описание не должно превышать 1500 символов");

        RuleFor(x => x.ProjectId)
            .NotEmpty()
            .WithMessage("Id проекта является обязательным для заполнения")
            .NotNull()
            .WithMessage("Id проекта является обязательным для заполнения");

        RuleFor(x => x.EstablishedTime)
            .NotNull()
            .NotEmpty();

        RuleFor(x=>x.SpentTime)
            .NotNull()
            .NotEmpty();
    }
}
