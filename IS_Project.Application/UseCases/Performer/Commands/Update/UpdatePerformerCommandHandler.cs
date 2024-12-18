using Model = IS_Project.Domain.Entities;
using MediatR;
using IS_Project.Application.Common.Data;
using Microsoft.EntityFrameworkCore;
using IS_Project.Application.Common.Exceptions;

namespace IS_Project.Application.UseCases.Performer.Commands.Update;

public class UpdatePerformerCommandHandler : IRequestHandler<UpdatePerformerCommand, Model.Performer>
{
    private readonly IApplicationDbContext _context;

    public UpdatePerformerCommandHandler(IApplicationDbContext context) => _context = context;
    
    public async Task<Model.Performer> Handle(UpdatePerformerCommand request, CancellationToken cancellationToken)
    {
        var performer = await _context.Performers
            .FirstOrDefaultAsync(x=>x.Id  == request.Id);

        if (performer is null)
            throw new NotFoundException(request.Id);

        performer.Id = request.Id;
        performer.FirstName = request.FirstName;
        performer.MiddleName = request.MiddleName;
        performer.LastName = request.LastName;
        performer.PhoneNumber = request.PhoneNumber;
        performer.AboutMe = request.AboutMe;

        _context.Performers.Update(performer);

        await _context.SaveChangesAsync(cancellationToken);

        return performer;
    }
}
