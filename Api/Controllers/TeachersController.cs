using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class TeachersController(
    ITeachersView teachersView,
    ITeachersService teachersService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> IndexAsync(
        [AsParameters] IndexTeachersParams parameters)
    {
        var teachers = await teachersService.FindManyAsync(parameters);
        var pagination = await teachersService.FindManyPaginationAsync(parameters);
        var data = teachersView.FindMany(teachers);

        return Ok(new
        {
            Data = data,
            Pagination = pagination
        });
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ShowAsync(
        [AsParameters] ShowTeachersParams parameters)
    {
        var teacher = await teachersService.FindOneAsync(parameters);
        var data = teachersView.FindOne(teacher);

        return Ok(new { Data = data });
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [AsParameters] CreateTeachersParams parameters)
    {
        var teacher = await teachersService.CreateAsync(parameters);
        var data = teachersView.Create(teacher);

        return Created($"teachers/{teacher.Id}", new { Data = data });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(
        [AsParameters] UpdateTeachersParams parameters)
    {
        await teachersService.UpdateAsync(parameters);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(
        [AsParameters] DeleteTeachersParams parameters)
    {
        await teachersService.DeleteAsync(parameters);

        return NoContent();
    }
}

public record IndexTeachersParams : PaginationParams
{
    public string? Name { get; set; }

    [FromHeader(Name = "X-Order-By-Name")]
    public string? OrderByName { get; set; }

    public static implicit operator FindManyServiceParams(IndexTeachersParams indexTeachersParams)
        => new()
        {
            FindManyProps = new FindManyTeachersParams
            {
                Name = indexTeachersParams.Name,
            },
            OrderByParams = new OrderByTeachersParams
            {
                Name = indexTeachersParams.OrderByName,
            },
            Includes = new IncludesTeachersParams
            {
                Unit = true,
                Position = true,
                Situation = true,
            },
            PaginationParams = indexTeachersParams
        };

    public static implicit operator FindManyPaginationServiceParams(IndexTeachersParams indexTeachersParams)
        => new()
        {
            CountProps = new CountTeachersParams
            {
                Name = indexTeachersParams.Name,
            },
            PaginationParams = indexTeachersParams
        };
}

public record ShowTeachersParams
{
    [FromRoute]
    public int Id { get; set; }

    [FromRoute]
    public bool? IncludeYear { get; set; } = true;
    [FromRoute]
    public bool? IncludeUnit { get; set; } = true;
    [FromRoute]
    public bool? IncludeCivilStatus { get; set; } = true;
    [FromRoute]
    public bool? IncludePosition { get; set; } = true;
    [FromRoute]
    public bool? IncludeDiscipline { get; set; } = true;
    [FromRoute]
    public bool? IncludeSituation { get; set; } = true;

    public static implicit operator FindOneServiceParams(ShowTeachersParams showTeachersParams)
        => new()
        {
            Id = showTeachersParams.Id,
            Includes = new IncludesTeachersParams
            {
                Year = showTeachersParams.IncludeYear,
                Unit = showTeachersParams.IncludeUnit,
                CivilStatus = showTeachersParams.IncludeCivilStatus,
                Position = showTeachersParams.IncludePosition,
                Discipline = showTeachersParams.IncludeDiscipline,
                Situation = showTeachersParams.IncludeSituation,
            },
        };
}

public record CreateTeachersParams
{
    [FromBody]
    public CreateTeachersRequest Request { get; set; } = new();

    public static implicit operator CreateServiceParams(CreateTeachersParams createTeachersParams)
        => new()
        {
            Props = createTeachersParams.Request,
        };
}

public record UpdateTeachersParams
{
    [FromRoute]
    public int Id { get; set; }

    [FromBody]
    public UpdateTeachersRequest Request { get; set; } = new();

    public static implicit operator UpdateServiceParams(UpdateTeachersParams createTeachersParams)
        => new()
        {
            Id = createTeachersParams.Id,
            Props = createTeachersParams.Request,
        };
}

public record DeleteTeachersParams
{
    [FromRoute]
    public int Id { get; set; }

    public static implicit operator DeleteServiceParams(DeleteTeachersParams showTeachersParams)
        => new()
        {
            Id = showTeachersParams.Id,
        };
}
