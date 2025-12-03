using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class SituationsController(
    ISituationsView situationsView,
    ISituationsService situationsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> IndexAsync(
        [AsParameters] IndexSituationsParams parameters)
    {
        var situations = await situationsService.FindManyAsync(parameters);
        var pagination = await situationsService.FindManyPaginationAsync(parameters);
        var data = situationsView.FindMany(situations);

        return Ok(new
        {
            Data = data,
            Pagination = pagination
        });
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ShowAsync(
        [AsParameters] ShowSituationsParams parameters)
    {
        var situation = await situationsService.FindOneAsync(parameters);
        var data = situationsView.FindOne(situation);

        return Ok(new { Data = data });
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [AsParameters] CreateSituationsParams parameters)
    {
        var situation = await situationsService.CreateAsync(parameters);
        var data = situationsView.Create(situation);

        return Created($"situations/{situation.Id}", new { Data = data });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(
        [AsParameters] UpdateSituationsParams parameters)
    {
        await situationsService.UpdateAsync(parameters);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(
        [AsParameters] DeleteSituationsParams parameters)
    {
        await situationsService.DeleteAsync(parameters);

        return NoContent();
    }
}

public record IndexSituationsParams : PaginationParams
{
    public string? Name { get; set; }

    [FromHeader(Name = "X-Order-By-Name")]
    public string? OrderByName { get; set; }

    public static implicit operator FindManyServiceParams(IndexSituationsParams indexSituationsParams)
        => new()
        {
            FindManyProps = new FindManySituationsParams
            {
                Name = indexSituationsParams.Name,
            },
            OrderByParams = new OrderBySituationsParams
            {
                Name = indexSituationsParams.OrderByName,
            },
            PaginationParams = indexSituationsParams
        };

    public static implicit operator FindManyPaginationServiceParams(IndexSituationsParams indexSituationsParams)
        => new()
        {
            CountProps = new CountSituationsParams
            {
                Name = indexSituationsParams.Name,
            },
            PaginationParams = indexSituationsParams
        };
}

public record ShowSituationsParams
{
    [FromRoute]
    public int Id { get; set; }

    public static implicit operator FindOneServiceParams(ShowSituationsParams showSituationsParams)
        => new()
        {
            Id = showSituationsParams.Id,
        };
}

public record CreateSituationsParams
{
    [FromBody]
    public CreateSituationsRequest Request { get; set; } = new();

    public static implicit operator CreateServiceParams(CreateSituationsParams createSituationsParams)
        => new()
        {
            Props = createSituationsParams.Request,
        };
}

public record UpdateSituationsParams
{
    [FromRoute]
    public int Id { get; set; }

    [FromBody]
    public UpdateSituationsRequest Request { get; set; } = new();

    public static implicit operator UpdateServiceParams(UpdateSituationsParams createSituationsParams)
        => new()
        {
            Id = createSituationsParams.Id,
            Props = createSituationsParams.Request,
        };
}

public record DeleteSituationsParams
{
    [FromRoute]
    public int Id { get; set; }

    public static implicit operator DeleteServiceParams(DeleteSituationsParams showSituationsParams)
        => new()
        {
            Id = showSituationsParams.Id,
        };
}
