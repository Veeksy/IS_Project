using FluentValidation;

namespace IS_Project.Application.UseCases.User.Commands.Delete;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id поле не должно быть пустым")
            .NotNull()
            .WithMessage("Id поле не должно быть пустым");
    }
}
