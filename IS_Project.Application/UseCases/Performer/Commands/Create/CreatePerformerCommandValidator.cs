using FluentValidation;

namespace IS_Project.Application.UseCases.Performer.Commands.Create;

public class CreatePerformerCommandValidator : AbstractValidator<CreatePerformerCommand>
{
    public CreatePerformerCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("имя не может быть пустым")
            .NotNull()
            .WithMessage("имя не может быть null")
            .MaximumLength(150);

        RuleFor(x => x.LastName)
           .NotEmpty()
           .WithMessage("фамилия не может быть пустой")
           .NotNull()
           .WithMessage("фамилия не может быть null")
           .MaximumLength(150);

    }
}
