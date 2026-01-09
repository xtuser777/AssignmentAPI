using Assignment.Api.Responses;

namespace Assignment.Api.Interfaces.Views;

public interface IAuthView
{
    AuthResponse Login(string token);
}