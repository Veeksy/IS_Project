using FluentValidation;

namespace IS_Project.Application.UseCases.Performer.Queries.GetPerformer;

public class GetPerformerQueryValidator : AbstractValidator<GetPerformerQuery>
{
    public GetPerformerQueryValidator() 
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id не может быть пустым.")
            .Must(id => id != Guid.Empty)
            .WithMessage("Id не может быть empty");
    }
}
