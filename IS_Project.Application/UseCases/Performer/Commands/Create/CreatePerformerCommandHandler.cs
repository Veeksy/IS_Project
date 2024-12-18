using IS_Project.Application.Common.Data;
using MediatR;

namespace IS_Project.Application.UseCases.Performer.Commands.Create;

public class CreatePerformerCommandHandler : IRequestHandler<CreatePerformerCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    public CreatePerformerCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Guid> Handle(CreatePerformerCommand request, CancellationToken cancellationToken)
    {
        var newPerf = new Domain.Entities.Performer
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            MiddleName = request.MiddleName,
            PhoneNumber = request.PhoneNumber,
            AboutMe = request.AboutMe,
        };

        _context.Performers.Add(newPerf);

        await _context.SaveChangesAsync(cancellationToken);

        return newPerf.Id;
    }
}