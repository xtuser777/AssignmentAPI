using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class PositionsController(
    IPositionsView positionsView,
    IPositionsService positionsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> IndexAsync(
        [AsParameters] IndexPositionsParams parameters)
    {
        var positions = await positionsService.FindManyAsync(parameters);
        var pagination = await positionsService.FindManyPaginationAsync(parameters);
        var data = positionsView.FindMany(positions);

        return Ok(new
        {
            Data = data,
            Pagination = pagination
        });
    }

    [HttpGet("{positionId:int}")]
    public async Task<IActionResult> ShowAsync(
        [AsParameters] ShowPositionsParams parameters)
    {
        var position = await positionsService.FindOneAsync(parameters);
        var data = positionsView.FindOne(position);

        return Ok(new { Data = data });
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [AsParameters] CreatePositionsParams parameters)
    {
        var position = await positionsService.CreateAsync(parameters);
        var data = positionsView.Create(position);

        return Created($"positions/{position.PositionId}", new { Data = data });
    }

    [HttpPut("{positionId:int}")]
    public async Task<IActionResult> UpdateAsync(
        [AsParameters] UpdatePositionsParams parameters)
    {
        await positionsService.UpdateAsync(parameters);

        return NoContent();
    }

    [HttpDelete("{positionId:int}")]
    public async Task<IActionResult> DeleteAsync(
        [AsParameters] DeletePositionsParams parameters)
    {
        await positionsService.DeleteAsync(parameters);

        return NoContent();
    }
}

public record IndexPositionsParams : PaginationParams
{
    public string? Name { get; set; }
    public char? Active { get; set; }

    [FromHeader(Name = "X-Order-By-Name")]
    public string? OrderByName { get; set; }

    [FromHeader(Name = "X-Order-By--Active")]
    public string? OrderByActive { get; set; }

    public static implicit operator FindManyServiceParams(
        IndexPositionsParams indexPositionsParams)
        => new()
        {
            FindManyProps = new FindManyPositionsParams
            {
                Name = indexPositionsParams.Name,
                Active = indexPositionsParams.Active,
            },
            OrderByParams = new OrderByPositionsParams
            {
                Name = indexPositionsParams.OrderByName,
                Active = indexPositionsParams.OrderByActive,
            },
            PaginationParams = indexPositionsParams
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexPositionsParams indexPositionsParams)
        => new()
        {
            CountProps = new CountPositionsParams
            {
                Name = indexPositionsParams.Name,
                Active = indexPositionsParams.Active,
            },
            PaginationParams = indexPositionsParams
        };
}

public record ShowPositionsParams
{
    [FromRoute]
    public int PositionId { get; set; }

    public static implicit operator FindOneServiceParams(
        ShowPositionsParams showPositionsParams)
        => new()
        {
            Where = new FindManyPositionsParams
            {
                PositionId = showPositionsParams.PositionId,
            }
        };
}

public record CreatePositionsParams
{
    [FromBody]
    public CreatePositionsRequest Request { get; set; } = new();

    public static implicit operator CreateServiceParams(
        CreatePositionsParams createPositionsParams)
        => new()
        {
            Props = createPositionsParams.Request,
        };
}

public record UpdatePositionsParams
{
    [FromRoute]
    public int PositionId { get; set; }

    [FromBody]
    public UpdatePositionsRequest Request { get; set; } = new();

    public static implicit operator UpdateServiceParams(
        UpdatePositionsParams updatePositionsParams)
        => new()
        {
            Where = new FindManyPositionsParams
            {
                PositionId = updatePositionsParams.PositionId,
            },
            Props = updatePositionsParams.Request,
        };
}

public record DeletePositionsParams
{
    [FromRoute]
    public int PositionId { get; set; }

    public static implicit operator DeleteServiceParams(
        DeletePositionsParams deletePositionsParams)
        => new()
        {
            Where = new FindManyPositionsParams
            {
                PositionId = deletePositionsParams.PositionId,
            },
        };
}
