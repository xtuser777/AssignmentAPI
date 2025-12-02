using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class TitlesController(
    ITitlesView titlesView,
    ITitlesService titlesService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> IndexAsync(
        [AsParameters] IndexTitlesParams parameters)
    {
        var titles = await titlesService.FindManyAsync(parameters);
        var pagination = await titlesService.FindManyPaginationAsync(parameters);
        var data = titlesView.FindMany(titles);

        return Ok(new
        {
            Data = data,
            Pagination = pagination
        });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> ShowAsync(
        [AsParameters] ShowTitlesParams parameters)
    {
        var title = await titlesService.FindOneAsync(parameters);
        var data = titlesView.FindOne(title);

        return Ok(new { Data = data });
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [AsParameters] CreateTitlesParams parameters)
    {
        var title = await titlesService.CreateAsync(parameters);
        var data = titlesView.Create(title);

        return Created($"titles/{title.Id}", new { Data = data });
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(
        [AsParameters] UpdateTitlesParams parameters)
    {
        await titlesService.UpdateAsync(parameters);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(
        [AsParameters] DeleteTitlesParams parameters)
    {
        await titlesService.DeleteAsync(parameters);

        return NoContent();
    }
}

public record IndexTitlesParams : PaginationParams
{
    public string? Alias { get; set; }
    public string? Description { get; set; }
    public decimal? Weight { get; set; }
    public decimal? Max { get; set; }
    public int? Order { get; set; }
    public char? Type { get; set; }
    public bool? IsActive { get; set; }
    public Guid? YearId { get; set; }

    [FromHeader(Name = "X-Order-By-Alias")]
    public string? OrderByAlias { get; set; }

    [FromHeader(Name = "X-Order-By-Description")]
    public string? OrderByDescription { get; set; }

    [FromHeader(Name = "X-Order-By-Weight")]
    public string? OrderByWeight { get; set; }

    [FromHeader(Name = "X-Order-By-Max")]
    public string? OrderByMax { get; set; }

    [FromHeader(Name = "X-Order-By-Order")]
    public string? OrderByOrder { get; set; }

    [FromHeader(Name = "X-Order-By-Type")]
    public string? OrderByType { get; set; }

    [FromHeader(Name = "X-Order-By-IsActive")]
    public string? OrderByIsActive { get; set; }

    [FromHeader(Name = "X-Order-By-Year")]
    public string? OrderByYear { get; set; }

    public static implicit operator FindManyServiceParams(IndexTitlesParams indexTitlesParams)
        => new()
        {
            FindManyProps = new FindManyTitlesParams
            {
                Alias = indexTitlesParams.Alias,
                Description = indexTitlesParams.Description,
                Weight = indexTitlesParams.Weight,
                Max = indexTitlesParams.Max,
                IsActive = indexTitlesParams.IsActive,
                YearId = indexTitlesParams.YearId,
                Order = indexTitlesParams.Order,
                Type = indexTitlesParams.Type,
            },
            OrderByParams = new OrderByTitlesParams
            {
                Alias = indexTitlesParams.OrderByAlias,
                Description = indexTitlesParams.OrderByDescription,
                Weight = indexTitlesParams.OrderByWeight,
                Max = indexTitlesParams.OrderByMax,
                IsActive = indexTitlesParams.OrderByIsActive,
                Year = indexTitlesParams.OrderByYear,
                Order = indexTitlesParams.OrderByOrder,
                Type = indexTitlesParams.OrderByType,
            },
            PaginationParams = indexTitlesParams
        };

    public static implicit operator FindManyPaginationServiceParams(IndexTitlesParams indexTitlesParams)
        => new()
        {
            CountProps = new CountTitlesParams
            {
                Alias = indexTitlesParams.Alias,
                Description = indexTitlesParams.Description,
                Weight = indexTitlesParams.Weight,
                Max = indexTitlesParams.Max,
                IsActive = indexTitlesParams.IsActive,
                YearId = indexTitlesParams.YearId,
                Order = indexTitlesParams.Order,
                Type = indexTitlesParams.Type,
            },
            PaginationParams = indexTitlesParams
        };
}

public record ShowTitlesParams
{
    [FromRoute]
    public Guid Id { get; set; }

    [FromRoute]
    public bool? IncludeYear { get; set; } = true;

    public static implicit operator FindOneServiceParams(ShowTitlesParams showTitlesParams)
        => new()
        {
            Id = showTitlesParams.Id,
            Includes = new IncludesTitlesParams
            {
                Year = showTitlesParams.IncludeYear,
            }
        };
}

public record CreateTitlesParams
{
    [FromBody]
    public CreateTitlesRequest Request { get; set; } = new();

    public static implicit operator CreateServiceParams(CreateTitlesParams createTitlesParams)
        => new()
        {
            Props = createTitlesParams.Request,
        };
}

public record UpdateTitlesParams
{
    [FromRoute]
    public Guid Id { get; set; }

    [FromBody]
    public UpdateTitlesRequest Request { get; set; } = new();

    public static implicit operator UpdateServiceParams(UpdateTitlesParams createTitlesParams)
        => new()
        {
            Id = createTitlesParams.Id,
            Props = createTitlesParams.Request,
        };
}

public record DeleteTitlesParams
{
    [FromRoute]
    public Guid Id { get; set; }

    public static implicit operator DeleteServiceParams(DeleteTitlesParams showTitlesParams)
        => new()
        {
            Id = showTitlesParams.Id,
        };
}
