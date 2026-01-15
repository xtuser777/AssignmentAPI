using Assignment.Api.Exceptions;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController(
        IAuthService authService,
        IAuthView authView) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> LoginAsync(
            [FromBody] AuthRequest request)
        {
            if (request == null)
            {
                throw new BadRequestException("Request cannot be null.");
            }

            var token = await authService.Login(
                request.Username, request.Password, request.YearId ?? 0);
            var data = authView.Login(token);

            return Ok(new
            {
                Data = data
            });
        }

        [HttpPatch("{username}")]
        public async Task<IActionResult> ResetPasswordAsync([AsParameters] ResetPasswordAuthParams parameters)
        {
            await authService.ResetPasswordAsync(parameters);

            return NoContent();
        }
    }

    public record ResetPasswordAuthParams
    {
        [FromRoute]
        public string Username { get; set; } = string.Empty;

        [FromBody]
        public ResetPasswordAuthRequest Request { get; set; } = new();

        public static implicit operator ResetPasswordParams(ResetPasswordAuthParams parameters)
            => new()
            {
                Username = parameters.Username,
                Password = parameters.Request.Password ?? "",
                NewPassword = parameters.Request.NewPassword ?? "",
            };
    }
}
