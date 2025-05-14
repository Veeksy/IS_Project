using IS_Project.Domain.Constants;
using IS_Project.Domain.Entities;

namespace IS_Project.Domain.AuthModels;

public class User
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required Performer PerformerData { get; set; }
    public string? RefreshToken { get; set; }  
    public DateTime? RefreshTokenExpiryTime { get; set; }
    public string Role { get; set; } = UserRoles.User;
}
