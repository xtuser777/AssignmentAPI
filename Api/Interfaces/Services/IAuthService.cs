namespace Assignment.Api.Interfaces.Services;

public interface IAuthService
{
    Task<string> Login(string username, string password, int yearId);
}