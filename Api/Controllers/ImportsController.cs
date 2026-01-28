using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Requests;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Api.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ImportsController(
    IImportsService service,
    IImportsView view) : ControllerBase
{
    [HttpGet()]
    public async Task<IActionResult> IndexAsync(
        [AsParameters] IndexImportsParams parameters)
    {
        var imports = await service.FindManyAsync(parameters);
        var pagination = await service.FindManyPaginationAsync(parameters);

        return Ok(new 
        { 
            data = view.FindMany(imports), 
            pagination
        });
    }

    [HttpGet("{importId:int}")]
    public async Task<IActionResult> ShowAsync(
        [AsParameters] ShowImportsParams parameters)
    {
        var import = await service.FindOneAsync(parameters);
        return Ok(new { data = view.FindOne(import) });
    }

    [HttpGet("exists")]
    public async Task<IActionResult> ExistsAsync(
        [FromQuery(Name = "yearId")] int yearId,
        [FromQuery(Name = "type")] string type)
    {
        var exists = await service.ExistsAsync(new () 
        { 
            Where = new ExistsImportsParams 
            { 
                YearId = yearId, 
                Type = type 
            } 
        });
        return Ok(new { data = exists });
    }

    [HttpPost()]
    public async Task<IActionResult> CreateAsync(
        [AsParameters] CreateImportsParams parameters)
    {
        var import = await service.CreateAsync(parameters);
        return CreatedAtAction(
            nameof(ShowAsync),
            new { import.ImportId },
            new { data = view.Create(import) });
    }
}

public record IndexImportsParams : PaginationParams
{
    [FromQuery(Name = "yearId")] public int? YearId { get; set; }
    [FromQuery(Name = "date")] public DateOnly? Date { get; set; }
    [FromQuery(Name = "time")] public TimeOnly? Time { get; set; }
    [FromQuery(Name = "type")] public string? Type { get; set; }
    [FromQuery(Name = "login")] public string? Login { get; set; }

    [FromHeader(Name = "X-Order-By-Year-Id")]
    public string? OrderByYearId { get; set; }
    [FromHeader(Name = "X-Order-By-Date")]
    public string? OrderByDate { get; set; }
    [FromHeader(Name = "X-Order-By-Time")]
    public string? OrderByTime { get; set; }
    [FromHeader(Name = "X-Order-By-Type")]
    public string? OrderByType { get; set; }
    [FromHeader(Name = "X-Order-By-Login")]
    public string? OrderByLogin { get; set; }

    public static implicit operator FindManyServiceParams(IndexImportsParams request)
    {
        return new FindManyServiceParams
        {
            FindManyProps = new FindManyImportsParams
            {
                YearId = request.YearId,
                Date = request.Date,
                Time = request.Time,
                Type = request.Type,
                Login = request.Login
            },
            OrderByParams = new OrderByImportsParams
            {
                YearId = request.OrderByYearId,
                Date = request.OrderByDate,
                Time = request.OrderByTime,
                Type = request.OrderByType,
                Login = request.OrderByLogin
            },
            PaginationParams = request
        };
    }

    public static implicit operator FindManyPaginationServiceParams(IndexImportsParams request)
    {
        return new FindManyPaginationServiceParams
        {
            CountProps = new CountImportsParams
            {
                YearId = request.YearId,
                Date = request.Date,
                Time = request.Time,
                Type = request.Type,
                Login = request.Login
            },
            PaginationParams = request
        };
    }
}

public record ShowImportsParams
{
    [FromRoute(Name = "importId")] public int? ImportId { get; set; }

    public static implicit operator FindOneServiceParams(ShowImportsParams request)
    {
        return new FindOneServiceParams
        {
            Where = new FindManyImportsParams
            {
                ImportId = request.ImportId,
            }
        };
    }
}

public record CreateImportsParams
{
    [FromBody]
    public CreateImportsRequest Request { get; set; } = null!;

    public static implicit operator CreateServiceParams(CreateImportsParams request)
    {
        return new CreateServiceParams
        {
            Props = request.Request,
        };
    }
}
