using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class UnitsController(
    IUnitsView unitsView,
    IUnitsService unitsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> IndexAsync(
        [AsParameters] IndexUnitsParams parameters)
    {
        var units = await unitsService.FindManyAsync(parameters);
        var pagination = await unitsService.FindManyPaginationAsync(parameters);
        var data = unitsView.FindMany(units);

        return Ok(new
        {
            Data = data,
            Pagination = pagination
        });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> ShowAsync(
        [AsParameters] ShowUnitsParams parameters)
    {
        var unit = await unitsService.FindOneAsync(parameters);
        var data = unitsView.FindOne(unit);

        return Ok(new { Data = data });
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [AsParameters] CreateUnitsParams parameters)
    {
        var unit = await unitsService.CreateAsync(parameters);
        var data = unitsView.Create(unit);

        return Created($"units/{unit.Id}", new { Data = data });
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(
        [AsParameters] UpdateUnitsParams parameters)
    {
        await unitsService.UpdateAsync(parameters);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(
        [AsParameters] DeleteUnitsParams parameters)
    {
        await unitsService.DeleteAsync(parameters);

        return NoContent();
    }
}

public record IndexUnitsParams : PaginationParams
{
    public string? Name { get; set; }

    [FromHeader(Name = "X-Order-By-Name")]
    public string? OrderByName { get; set; }

    public static implicit operator FindManyServiceParams(IndexUnitsParams indexUnitsParams)
        => new()
        {
            FindManyProps = new FindManyUnitsParams
            {
                Name = indexUnitsParams.Name,
            },
            OrderByParams = new OrderByUnitsParams
            {
                Name = indexUnitsParams.OrderByName,
            },
            PaginationParams = indexUnitsParams
        };

    public static implicit operator FindManyPaginationServiceParams(IndexUnitsParams indexUnitsParams)
        => new()
        {
            CountProps = new CountUnitsParams
            {
                Name = indexUnitsParams.Name,
            },
            PaginationParams = indexUnitsParams
        };
}

public record ShowUnitsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    public static implicit operator FindOneServiceParams(ShowUnitsParams showUnitsParams)
        => new()
        {
            Id = showUnitsParams.Id,
        };
}

public record CreateUnitsParams
{
    [FromBody]
    public CreateUnitsRequest Request { get; set; } = new();

    public static implicit operator CreateServiceParams(CreateUnitsParams createUnitsParams)
        => new()
        {
            Props = createUnitsParams.Request,
        };
}

public record UpdateUnitsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    [FromBody]
    public UpdateUnitsRequest Request { get; set; } = new();

    public static implicit operator UpdateServiceParams(UpdateUnitsParams createUnitsParams)
        => new()
        {
            Id = createUnitsParams.Id,
            Props = createUnitsParams.Request,
        };
}

public record DeleteUnitsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    public static implicit operator DeleteServiceParams(DeleteUnitsParams showUnitsParams)
        => new()
        {
            Id = showUnitsParams.Id,
        };
}
