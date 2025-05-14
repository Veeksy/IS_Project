using FluentValidation;

namespace IS_Project.Application.UseCases.User.Commands.Update;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email поле не должно быть пустым")
            .NotNull()
            .WithMessage("Email поле не должно быть пустым")
            .MaximumLength(150)
            .WithMessage("Превышена длина символов. Максимум 150");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name поле не должно быть пустым")
            .NotNull()
            .WithMessage("Name поле не должно быть пустым")
            .MaximumLength(150)
            .WithMessage("Превышена длина символов. Максимум 150");

        RuleFor(x => x.Role)
            .NotEmpty()
            .WithMessage("Role поле не должно быть пустым")
            .NotNull()
            .WithMessage("Role поле не должно быть пустым");
    }
}
