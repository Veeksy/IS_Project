using IS_Project.Application.Common.Data;
using Model = IS_Project.Domain.AuthModels;
using MediatR;
using IS_Project.Identity.PasswordHasher;

namespace IS_Project.Application.UseCases.User.Commands.Create;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IPasswordHasherService _hasher;

    public CreateUserCommandHandler(
        IApplicationDbContext context,
        IPasswordHasherService hasher)
    {
        _context = context;
        _hasher = hasher;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var performer = await _context.Performers.FindAsync(request.PerformerId, cancellationToken);

        var user = new Model.User()
        {
            Email = request.Email,
            Name = request.Name,
            Password = _hasher.HashPassword(request.Password),
            PerformerData = performer ?? throw new ArgumentException($"performer is null. Check performer with id {request.PerformerId} if is not null"),
        };

        _context.Users.Add(user);

        await _context.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
