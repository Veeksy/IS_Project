namespace IS_Project.Identity.PasswordHasher;

public interface IPasswordHasherService
{
    string HashPassword(string password);

    bool VerifyPassword(string password, string hashedPassword);
}
