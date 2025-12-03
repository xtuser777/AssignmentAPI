using Assignment.Api.Interfaces.Views;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Api.Controllers;

[Route("users-roles")]
[ApiController]
public class UsersRolesController(
    IUsersRolesView usersRolesView) : ControllerBase
{
    [HttpGet]
    public IActionResult IndexAsync()
    {
        var usersRoles = usersRolesView.FindMany();

        return Ok(new { Data = usersRoles });
    }
}
