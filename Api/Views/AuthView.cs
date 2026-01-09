using Assignment.Api.Interfaces.Views;
using Assignment.Api.Responses;

namespace Assignment.Api.Views;

public class AuthView : IAuthView
{
    public AuthResponse Login(string token)
    {
        return new AuthResponse
        {
            AccessToken = token, 
            ExpiresIn = 60 * 24 * 7
        };
    }
}