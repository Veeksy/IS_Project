using FluentValidation;

namespace IS_Project.Application.UseCases.User.Commands.Create;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
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

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password поле не должно быть пустым")
            .NotNull()
            .WithMessage("Password поле не должно быть пустым")
            .MinimumLength(3)
            .WithMessage("Минмальная длинна пароля 3 символа");
    }
}
