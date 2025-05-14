using IS_Project.Application.Common.Data;
using IS_Project.Application.Common.Exceptions;
using MediatR;

namespace IS_Project.Application.UseCases.User.Commands.Update;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public UpdateUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(request.Id, cancellationToken);

        if (user is null)
            throw new NotFoundException(request.Id);

        user.Email = request.Email;
        user.Name = request.Name;
        user.Role = request.Role;

        _context.Users.Update(user);

        await _context.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
