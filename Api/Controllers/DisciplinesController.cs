using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class DisciplinesController(
    IDisciplinesView disciplinesView,
    IDisciplinesService disciplinesService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> IndexAsync(
        [AsParameters] IndexDisciplinesParams parameters)
    {
        var disciplines = await disciplinesService.FindManyAsync(parameters);
        var pagination = await disciplinesService.FindManyPaginationAsync(parameters);
        var data = disciplinesView.FindMany(disciplines);

        return Ok(new
        {
            Data = data,
            Pagination = pagination
        });
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ShowAsync(
        [AsParameters] ShowDisciplinesParams parameters)
    {
        var discipline = await disciplinesService.FindOneAsync(parameters);
        var data = disciplinesView.FindOne(discipline);

        return Ok(new { Data = data });
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [AsParameters] CreateDisciplinesParams parameters)
    {
        var discipline = await disciplinesService.CreateAsync(parameters);
        var data = disciplinesView.Create(discipline);

        return Created($"disciplines/{discipline.Id}", new { Data = data });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(
        [AsParameters] UpdateDisciplinesParams parameters)
    {
        await disciplinesService.UpdateAsync(parameters);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(
        [AsParameters] DeleteDisciplinesParams parameters)
    {
        await disciplinesService.DeleteAsync(parameters);

        return NoContent();
    }
}

public record IndexDisciplinesParams : PaginationParams
{
    public string? Name { get; set; }

    [FromHeader(Name = "X-Order-By-Name")]
    public string? OrderByName { get; set; }

    public static implicit operator FindManyServiceParams(IndexDisciplinesParams indexDisciplinesParams)
        => new()
        {
            FindManyProps = new FindManyDisciplinesParams
            {
                Name = indexDisciplinesParams.Name,
            },
            OrderByParams = new OrderByDisciplinesParams
            {
                Name = indexDisciplinesParams.OrderByName,
            },
            PaginationParams = indexDisciplinesParams
        };

    public static implicit operator FindManyPaginationServiceParams(IndexDisciplinesParams indexDisciplinesParams)
        => new()
        {
            CountProps = new CountDisciplinesParams
            {
                Name = indexDisciplinesParams.Name,
            },
            PaginationParams = indexDisciplinesParams
        };
}

public record ShowDisciplinesParams
{
    [FromRoute]
    public int Id { get; set; }

    public static implicit operator FindOneServiceParams(ShowDisciplinesParams showDisciplinesParams)
        => new()
        {
            Id = showDisciplinesParams.Id,
        };
}

public record CreateDisciplinesParams
{
    [FromBody]
    public CreateDisciplinesRequest Request { get; set; } = new();

    public static implicit operator CreateServiceParams(CreateDisciplinesParams createDisciplinesParams)
        => new()
        {
            Props = createDisciplinesParams.Request,
        };
}

public record UpdateDisciplinesParams
{
    [FromRoute]
    public int Id { get; set; }

    [FromBody]
    public UpdateDisciplinesRequest Request { get; set; } = new();

    public static implicit operator UpdateServiceParams(UpdateDisciplinesParams createDisciplinesParams)
        => new()
        {
            Id = createDisciplinesParams.Id,
            Props = createDisciplinesParams.Request,
        };
}

public record DeleteDisciplinesParams
{
    [FromRoute]
    public int Id { get; set; }

    public static implicit operator DeleteServiceParams(DeleteDisciplinesParams showDisciplinesParams)
        => new()
        {
            Id = showDisciplinesParams.Id,
        };
}
