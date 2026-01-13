namespace Assignment.Api.Interfaces.Services;

public interface IAuthService
{
    Task<string> Login(string username, string password, int yearId);
    Task ResetPasswordAsync(ResetPasswordParams parameters);
}

public record ResetPasswordParams
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string NewPassword { get; set; }
}