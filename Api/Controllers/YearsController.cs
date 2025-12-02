using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class YearsController(
    IYearsView yearsView,
    IYearsService yearsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> IndexAsync([AsParameters] IndexYearsParams parameters)
    {
        var years = await yearsService.FindManyAsync(parameters);
        var pagination = await yearsService.FindManyPaginationAsync(parameters);
        var data = yearsView.FindMany(years);

        return Ok(new
        {
            Data = data,
            Pagination = pagination
        });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> ShowAsync([AsParameters] ShowYearsParams parameters)
    {
        var year = await yearsService.FindOneAsync(parameters);
        var data = yearsView.FindOne(year);

        return Ok(new { Data = data });
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([AsParameters] CreateYearsParams parameters)
    {
        var year = await yearsService.CreateAsync(parameters);
        var data = yearsView.Create(year);

        return Created($"years/{year.Id}", new { Data = data });
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync([AsParameters] UpdateYearsParams parameters)
    {
        await yearsService.UpdateAsync(parameters);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync([AsParameters]  DeleteYearsParams parameters)
    {
        await yearsService.DeleteAsync(parameters);

        return NoContent();
    }
}

public record IndexYearsParams : PaginationParams
{
    public int? Value { get; set; }
    public string? Record { get; set; }
    public string? Resolution { get; set; }
    public bool? IsBlocked { get; set; }

    [FromHeader(Name = "Order-By-Value")]
    public string? OrderByValue { get; set; }

    [FromHeader(Name = "Order-By-Record")]
    public string? OrderByRecord { get; set; }

    [FromHeader(Name = "Order-By-Resolution")]
    public string? OrderByResolution { get; set; }

    [FromHeader(Name = "Order-By-IsBlocked")]
    public string? OrderByIsBlocked { get; set; }

    public static implicit operator FindManyServiceParams(IndexYearsParams parameters)
        => new()
        {
            FindManyProps = new FindManyYearsParams
            {
                Value = parameters.Value,
                Record = parameters.Record,
                Resolution = parameters.Resolution,
                IsBlocked = parameters.IsBlocked,
            },
            OrderByParams = new OrderByYearsParams
            {
                Value = parameters.OrderByValue,
                Record = parameters.OrderByRecord,
                Resolution = parameters.OrderByResolution,
                IsBlocked = parameters.OrderByIsBlocked,
            },
            PaginationParams = parameters,
        };

    public static implicit operator FindManyPaginationServiceParams(IndexYearsParams parameters)
        => new()
        {
            CountProps = new CountYearParams
            {
                Value = parameters.Value,
                Record = parameters.Record,
                Resolution = parameters.Resolution,
                IsBlocked = parameters.IsBlocked,
            },
            PaginationParams = parameters,
        };
}

public record ShowYearsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    public static implicit operator FindOneServiceParams(ShowYearsParams parameters)
        => new()
        {
            Id = parameters.Id,
        };
}

public record CreateYearsParams
{
    [FromBody]
    public CreateYearsRequest Request { get; set; } = new();

    public static implicit operator CreateServiceParams(CreateYearsParams parameters)
        => new()
        {
            Props = parameters.Request,
        };
}

public record UpdateYearsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    [FromBody]
    public UpdateYearsRequest Request { get; set; } = new();

    public static implicit operator UpdateServiceParams(UpdateYearsParams parameters)
        => new()
        {
            Id = parameters.Id,
            Props = parameters.Request,
        };
}

public record DeleteYearsParams
{
    [FromRoute]
    public Guid Id { get; set; }

    public static implicit operator DeleteServiceParams(DeleteYearsParams parameters)
        => new()
        {
            Id = parameters.Id,
        };
}
