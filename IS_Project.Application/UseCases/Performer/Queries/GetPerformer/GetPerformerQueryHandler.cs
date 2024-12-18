using Model = IS_Project.Domain.Entities;
using MediatR;
using IS_Project.Application.Common.Data;
using Microsoft.EntityFrameworkCore;
using IS_Project.Application.Common.Exceptions;

namespace IS_Project.Application.UseCases.Performer.Queries.GetPerformer;

public class GetPerformerQueryHandler : IRequestHandler<GetPerformerQuery, Model.Performer>
{
    private readonly IApplicationDbContext _context;

    public GetPerformerQueryHandler(IApplicationDbContext context) => _context = context;

    public async Task<Model.Performer> Handle(GetPerformerQuery request, CancellationToken cancellationToken)
    {
        var performer = await _context.Performers
            .FirstOrDefaultAsync(x=>x.Id == request.Id, cancellationToken);

        if (performer is null)
            throw new NotFoundException(request.Id);

        return performer;
    }
}
