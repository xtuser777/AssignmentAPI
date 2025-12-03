using Assignment.Api.Enums;
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

    [HttpGet("{id:int}")]
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

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync([AsParameters] UpdateUsersParams parameters)
    {
        await usersService.UpdateAsync(parameters);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
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
    public bool? IsActive { get; set; }
    public string? Role { get; set; }

    [FromHeader(Name = "X-Order-By-Username")]
    public string? OrderByUsername { get; set; }
    [FromHeader(Name = "X-Order-By-Name")]
    public string? OrderByName { get; set; }
    [FromHeader(Name = "X-Order-By-Email")]
    public string? OrderByEmail { get; set; }
    [FromHeader(Name = "X-Order-By-IsActive")]
    public string? OrderByIsActive { get; set; }
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
                IsActive = parameters.IsActive,
                Role = Parser.ToEnumOptional<UserRole>(parameters.Role)
            },
            OrderByParams = new OrderByUsersParams
            {
                Username = parameters.OrderByUsername,
                Name = parameters.OrderByName,
                Email = parameters.OrderByEmail,
                IsActive = parameters.OrderByIsActive,
                Role = parameters.OrderByRole,
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
                IsActive = parameters.IsActive,
                Role = Parser.ToEnumOptional<UserRole>(parameters.Role)
            },
            PaginationParams = parameters,
        };
    }
}

public record ShowUsersParams
{
    [FromRoute]
    public int Id { get; set; }

    [FromRoute]
    public bool? IncludeUsersUnits { get; set; } = true;

    public static implicit operator FindOneServiceParams(ShowUsersParams parameters)
        => new()
        {
            Id = parameters.Id,
            Includes = new IncludesUsersParams
            {
                UsersUnits = new IncludesUsersUnitsParams
                {
                    Unit = true,
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
    public int Id { get; set; }

    [FromBody]
    public UpdateUsersRequest Request { get; set; } = new();

    public static implicit operator UpdateServiceParams(UpdateUsersParams parameters)
        => new()
        {
            Id = parameters.Id,
            Props = parameters.Request,
        };
}

public record DeleteUsersParams
{
    [FromRoute]
    public int Id { get; set; }

    public static implicit operator DeleteServiceParams(DeleteUsersParams parameters)
        => new()
        {
            Id = parameters.Id,
        };
}
