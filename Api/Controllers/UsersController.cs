using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Requests;
using Assignment.Api.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController(
    IUsersView usersView,
    IUsersService usersService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> IndexAsync([AsParameters] IndexUsersParams parameters)
    {
        var users = await usersService.FindManyAsync(parameters);
        var pagination = await usersService.FindManyPaginationAsync(parameters);
        var data = usersView.FindMany(users);

        return Ok(new
        {
            Data = data,
            Pagination = pagination
        });
    }

    [HttpGet("{username}")]
    public async Task<IActionResult> ShowAsync([AsParameters] ShowUsersParams parameters)
    {
        var user = await usersService.FindOneAsync(parameters);
        var data = usersView.FindOne(user);

        return Ok(new
        {
            Data = data,
        });
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([AsParameters] CreateUsersParams parameters)
    {
        var user = await usersService.CreateAsync(parameters);
        var data = usersView.Create(user);

        return Ok(new
        {
            Data = data,
        });
    }

    [HttpPut("{username}")]
    public async Task<IActionResult> UpdateAsync([AsParameters] UpdateUsersParams parameters)
    {
        await usersService.UpdateAsync(parameters);

        return NoContent();
    }

    [HttpDelete("{username}")]
    public async Task<IActionResult> DeleteAsync([AsParameters] DeleteUsersParams parameters)
    {
        await usersService.DeleteAsync(parameters);

        return NoContent();
    }
}

public record IndexUsersParams : PaginationParams
{
    public string? Username { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public char? Active { get; set; }
    public string? Role { get; set; }

    [FromHeader(Name = "X-Order-By-Username")]
    public string? OrderByUsername { get; set; }
    [FromHeader(Name = "X-Order-By-Name")]
    public string? OrderByName { get; set; }
    [FromHeader(Name = "X-Order-By-Email")]
    public string? OrderByEmail { get; set; }
    [FromHeader(Name = "X-Order-By-Active")]
    public string? OrderByActive { get; set; }
    [FromHeader(Name = "X-Order-By-Role")]
    public string? OrderByRole { get; set; }

    public static implicit operator FindManyServiceParams(IndexUsersParams parameters)
    {
        return new FindManyServiceParams
        {
            FindManyProps = new FindManyUsersParams
            {
                Username = parameters.Username,
                Name = parameters.Name,
                Email = parameters.Email,
                Active = parameters.Active,
            },
            OrderByParams = new OrderByUsersParams
            {
                Username = parameters.OrderByUsername,
                Name = parameters.OrderByName,
                Email = parameters.OrderByEmail,
                Active = parameters.OrderByActive,
            },
            Includes = new IncludesUsersParams
            {
                UsersRoles = new IncludesUsersUsersRolesParams { Role = true },
                UsersUnits = new IncludesUsersUsersUnitsParams { Unit = true }
            },
            PaginationParams = parameters,
        };
    }

    public static implicit operator FindManyPaginationServiceParams(IndexUsersParams parameters)
    {
        return new FindManyPaginationServiceParams
        {
            CountProps = new CountUsersParams
            {
                Username = parameters.Username,
                Name = parameters.Name,
                Email = parameters.Email,
                Active = parameters.Active,
            },
            PaginationParams = parameters,
        };
    }
}

public record ShowUsersParams
{
    [FromRoute]
    public string Username { get; set; } = string.Empty;

    [FromRoute]
    public bool? IncludeUsersUnits { get; set; } = true;

    [FromRoute]
    public bool? IncludeUsersRoles { get; set; } = true;

    public static implicit operator FindOneServiceParams(ShowUsersParams parameters)
        => new()
        {
            Where = new FindManyUsersParams
            {
                Username = parameters.Username
            },
            Includes = new IncludesUsersParams
            {
                UsersRoles = new IncludesUsersUsersRolesParams
                {
                    Role = parameters.IncludeUsersRoles
                },
                UsersUnits = new IncludesUsersUsersUnitsParams
                {
                    Unit = parameters.IncludeUsersUnits,
                }
            }
        };
}

public record CreateUsersParams
{
    [FromBody]
    public CreateUsersRequest Request { get; set; } = new();

    public static implicit operator CreateServiceParams(CreateUsersParams parameters)
        => new()
        {
            Props = parameters.Request,
        };
}

public record UpdateUsersParams
{
    [FromRoute]
    public string Username { get; set; } = string.Empty;

    [FromBody]
    public UpdateUsersRequest Request { get; set; } = new();

    public static implicit operator UpdateServiceParams(UpdateUsersParams parameters)
        => new()
        {
            Where = new FindManyUsersParams
            { 
                Username = parameters.Username 
            },
            Props = parameters.Request,
        };
}

public record DeleteUsersParams
{
    [FromRoute]
    public string Username { get; set; } = string.Empty;

    public static implicit operator DeleteServiceParams(DeleteUsersParams parameters)
        => new()
        {
            Where = new FindManyUsersParams
            { 
                Username = parameters.Username 
            },
        };
}
