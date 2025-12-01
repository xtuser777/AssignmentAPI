namespace Assignment.Api.Interfaces.Services;

public interface ICryptService
{
    string HashPassword(string password);
    bool VerifyHashedPassword(string hashedPassword, string password);
}
