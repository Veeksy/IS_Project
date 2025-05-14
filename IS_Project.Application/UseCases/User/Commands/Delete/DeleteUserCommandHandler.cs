using IS_Project.Application.Common.Data;
using IS_Project.Application.Common.Exceptions;
using MediatR;

namespace IS_Project.Application.UseCases.User.Commands.Delete;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(request.Id, cancellationToken);

        if (user is null)
            throw new NotFoundException(request.Id);

        _context.Users.Remove(user);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
