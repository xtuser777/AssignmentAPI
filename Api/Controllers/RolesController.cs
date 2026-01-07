using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Interfaces.Views;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class RolesController(
    IRolesService service, IRolesView view) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> IndexAsync([AsParameters] IndexRolesParams parameters)
    {
        var roles = await service.FindManyAsync(parameters);
        var pagination = await service.FindManyPaginationAsync(parameters);
        var data = view.FindMany(roles);
        return Ok(new { data, pagination });
    }

    [HttpGet("{roleId:int}")]
    public async Task<IActionResult> ShowAsync([AsParameters] ShowRolesParams parameters) 
    { 
        var role = await service.FindOneAsync(parameters);
        var data = view.FindOne(role);
        return Ok(new { data }); 
    }
}

public record IndexRolesParams : PaginationParams
{
    [FromQuery]
    public string? Description { get; init; }

    [FromHeader(Name = "X-Order-By-Description")]
    public string? OrderByDescription { get; init; }

    public static implicit operator FindManyServiceParams(IndexRolesParams parameters)
    {
        return new FindManyServiceParams
        {
            FindManyProps = new FindManyRolesParams
            {
                Description = parameters.Description,
            },
            OrderByParams = new OrderByRolesParams
            {
                Description = parameters.OrderByDescription,
            },
            PaginationParams = parameters
        };
    }

    public static implicit operator FindManyPaginationServiceParams(IndexRolesParams parameters)
    {
        return new FindManyPaginationServiceParams
        {
            CountProps = new FindManyRolesParams
            {
                Description = parameters.Description,
            },
            PaginationParams = parameters
        };
    }
}

public record ShowRolesParams
{
    [FromRoute]
    public int RoleId { get; set; }

    public static implicit operator FindOneServiceParams(ShowRolesParams parameters)
    {
        return new FindOneServiceParams { 
            Where = new FindManyRolesParams
            {
                RoleId = parameters.RoleId,
            }
        };
    }
}
