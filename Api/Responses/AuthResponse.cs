namespace Assignment.Api.Responses;

public record AuthResponse
{
    public int ExpiresIn { get; set; }
    public string AccessToken { get; set; } = string.Empty;
}

public class LoginPayload
{
    public string Sub { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Year { get; set; } = string.Empty;
}
