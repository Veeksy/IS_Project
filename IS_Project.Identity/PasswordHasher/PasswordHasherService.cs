using Microsoft.AspNet.Identity;
using IdentifierCase = Microsoft.AspNet.Identity;

namespace IS_Project.Identity.PasswordHasher;

public class PasswordHasherService : IPasswordHasherService
{
    private readonly IdentifierCase.PasswordHasher _passwordHasher;

    public PasswordHasherService()
    {
        _passwordHasher = new IdentifierCase.PasswordHasher();
    }

    public string HashPassword(string password)
    {
        return _passwordHasher.HashPassword(password);
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        var result = _passwordHasher.VerifyHashedPassword(hashedPassword, password);
        
        return result == PasswordVerificationResult.Success;
    }
}
