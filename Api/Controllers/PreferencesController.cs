using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class PreferencesController(
    IPreferencesView preferencesView,
    IPreferencesService preferencesService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> IndexAsync(
        [AsParameters] IndexPreferencesParams parameters)
    {
        var preferences = await preferencesService.FindManyAsync(parameters);
        var pagination = await preferencesService.FindManyPaginationAsync(parameters);
        var data = preferencesView.FindMany(preferences);

        return Ok(new
        {
            Data = data,
            Pagination = pagination
        });
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ShowAsync(
        [AsParameters] ShowPreferencesParams parameters)
    {
        var preference = await preferencesService.FindOneAsync(parameters);
        var data = preferencesView.FindOne(preference);

        return Ok(new { Data = data });
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [AsParameters] CreatePreferencesParams parameters)
    {
        var preference = await preferencesService.CreateAsync(parameters);
        var data = preferencesView.Create(preference);

        return Created($"preferences/{preference.Id}", new { Data = data });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(
        [AsParameters] UpdatePreferencesParams parameters)
    {
        await preferencesService.UpdateAsync(parameters);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(
        [AsParameters] DeletePreferencesParams parameters)
    {
        await preferencesService.DeleteAsync(parameters);

        return NoContent();
    }
}

public record IndexPreferencesParams : PaginationParams
{
    public string? Name { get; set; }

    [FromHeader(Name = "X-Order-By-Name")]
    public string? OrderByName { get; set; }

    public static implicit operator FindManyServiceParams(IndexPreferencesParams indexPreferencesParams)
        => new()
        {
            FindManyProps = new FindManyPreferencesParams
            {
                Name = indexPreferencesParams.Name,
            },
            OrderByParams = new OrderByPreferencesParams
            {
                Name = indexPreferencesParams.OrderByName,
            },
            PaginationParams = indexPreferencesParams
        };

    public static implicit operator FindManyPaginationServiceParams(IndexPreferencesParams indexPreferencesParams)
        => new()
        {
            CountProps = new CountPreferencesParams
            {
                Name = indexPreferencesParams.Name,
            },
            PaginationParams = indexPreferencesParams
        };
}

public record ShowPreferencesParams
{
    [FromRoute]
    public int Id { get; set; }

    public static implicit operator FindOneServiceParams(ShowPreferencesParams showPreferencesParams)
        => new()
        {
            Id = showPreferencesParams.Id,
        };
}

public record CreatePreferencesParams
{
    [FromBody]
    public CreatePreferencesRequest Request { get; set; } = new();

    public static implicit operator CreateServiceParams(CreatePreferencesParams createPreferencesParams)
        => new()
        {
            Props = createPreferencesParams.Request,
        };
}

public record UpdatePreferencesParams
{
    [FromRoute]
    public int Id { get; set; }

    [FromBody]
    public UpdatePreferencesRequest Request { get; set; } = new();

    public static implicit operator UpdateServiceParams(UpdatePreferencesParams createPreferencesParams)
        => new()
        {
            Id = createPreferencesParams.Id,
            Props = createPreferencesParams.Request,
        };
}

public record DeletePreferencesParams
{
    [FromRoute]
    public int Id { get; set; }

    public static implicit operator DeleteServiceParams(DeletePreferencesParams showPreferencesParams)
        => new()
        {
            Id = showPreferencesParams.Id,
        };
}
