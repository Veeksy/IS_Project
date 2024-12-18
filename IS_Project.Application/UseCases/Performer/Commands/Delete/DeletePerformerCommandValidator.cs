using FluentValidation;

namespace IS_Project.Application.UseCases.Performer.Commands.Delete;
public class DeletePerformerCommandValidator : AbstractValidator<DeletePerformerCommand>
{
    public DeletePerformerCommandValidator() 
    {
        RuleFor(x => x.Id)
          .NotEmpty()
          .WithMessage("id не должно быть пустым.");
    }
}
