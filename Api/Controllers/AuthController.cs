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
                request.Username, request.Password, request.YearId);
            var data = authView.Login(token);

            return Ok(new
            {
                Data = data
            });
        }
    }
}
