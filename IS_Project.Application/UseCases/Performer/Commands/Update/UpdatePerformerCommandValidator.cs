using FluentValidation;

namespace IS_Project.Application.UseCases.Performer.Commands.Update;

public class UpdatePerformerCommandValidator : AbstractValidator<UpdatePerformerCommand>
{
    public UpdatePerformerCommandValidator() 
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id не может быть пустым")
            .NotNull()
            .WithMessage("Id не может быть null");

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

        RuleFor(c => c.PhoneNumber)
            .MinimumLength(11).WithMessage("Номер должен содержать 11 цифр.")
            .MaximumLength(11).WithMessage("Номер должен содержать 11 цифр.");
    }
}
