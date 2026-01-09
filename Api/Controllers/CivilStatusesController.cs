using Assignment.Api.Interfaces.Repositories;
using Assignment.Api.Interfaces.Services;
using Assignment.Api.Interfaces.Views;
using Assignment.Api.Requests;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Api.Controllers;

[Route("civil-statuses")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class CivilStatusesController(
    ICivilStatusesView civilStatusesView,
    ICivilStatusesService civilStatusesService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> IndexAsync(
        [AsParameters] IndexCivilStatusesParams parameters)
    {
        var civilStatuses = await civilStatusesService.FindManyAsync(parameters);
        var pagination = await civilStatusesService.FindManyPaginationAsync(parameters);
        var data = civilStatusesView.FindMany(civilStatuses);

        return Ok(new
        {
            Data = data,
            Pagination = pagination
        });
    }

    [HttpGet("{civilStatusId:int}")]
    public async Task<IActionResult> ShowAsync(
        [AsParameters] ShowCivilStatusesParams parameters)
    {
        var civilStatus = await civilStatusesService.FindOneAsync(parameters);
        var data = civilStatusesView.FindOne(civilStatus);

        return Ok(new { Data = data });
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [AsParameters] CreateCivilStatusesParams parameters)
    {
        var civilStatus = await civilStatusesService.CreateAsync(parameters);
        var data = civilStatusesView.Create(civilStatus);

        return Created($"civil-statuses/{civilStatus.CivilStatusId}", new { Data = data });
    }

    [HttpPut("{civilStatusId:int}")]
    public async Task<IActionResult> UpdateAsync(
        [AsParameters] UpdateCivilStatusesParams parameters)
    {
        await civilStatusesService.UpdateAsync(parameters);

        return NoContent();
    }

    [HttpDelete("{civilStatusId:int}")]
    public async Task<IActionResult> DeleteAsync(
        [AsParameters] DeleteCivilStatusesParams parameters)
    {
        await civilStatusesService.DeleteAsync(parameters);

        return NoContent();
    }
}

public record IndexCivilStatusesParams : PaginationParams
{
    public string? Name { get; set; }

    [FromHeader(Name = "X-Order-By-Name")]
    public string? OrderByName { get; set; }

    public static implicit operator FindManyServiceParams(
        IndexCivilStatusesParams indexCivilStatusesParams)
        => new()
        {
            FindManyProps = new FindManyCivilStatusesParams
            {
                Name = indexCivilStatusesParams.Name,
            },
            OrderByParams = new OrderByCivilStatusesParams
            {
                Name = indexCivilStatusesParams.OrderByName,
            },
            PaginationParams = indexCivilStatusesParams
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexCivilStatusesParams indexCivilStatusesParams)
        => new()
        {
            CountProps = new CountCivilStatusesParams
            {
                Name = indexCivilStatusesParams.Name,
            },
            PaginationParams = indexCivilStatusesParams
        };
}

public record ShowCivilStatusesParams
{
    [FromRoute]
    public int CivilStatusId { get; set; }

    public static implicit operator FindOneServiceParams(
        ShowCivilStatusesParams showCivilStatusesParams)
        => new()
        {
            Where = new FindManyCivilStatusesParams
            {
                CivilStatusId = showCivilStatusesParams.CivilStatusId,
            }
        };
}

public record CreateCivilStatusesParams
{
    [FromBody]
    public CreateCivilStatusesRequest Request { get; set; } = new();

    public static implicit operator CreateServiceParams(
        CreateCivilStatusesParams createCivilStatusesParams)
        => new()
        {
            Props = createCivilStatusesParams.Request,
        };
}

public record UpdateCivilStatusesParams
{
    [FromRoute]
    public int CivilStatusId { get; set; }

    [FromBody]
    public UpdateCivilStatusesRequest Request { get; set; } = new();

    public static implicit operator UpdateServiceParams(
        UpdateCivilStatusesParams updateCivilStatusesParams)
        => new()
        {
            Where = new FindManyCivilStatusesParams
            {
                CivilStatusId = updateCivilStatusesParams.CivilStatusId,
            },
            Props = updateCivilStatusesParams.Request,
        };
}

public record DeleteCivilStatusesParams
{
    [FromRoute]
    public int CivilStatusId { get; set; }

    public static implicit operator DeleteServiceParams(
        DeleteCivilStatusesParams deleteCivilStatusesParams)
        => new()
        {
            Where = new FindManyCivilStatusesParams
            {
                CivilStatusId = deleteCivilStatusesParams.CivilStatusId,
            },
        };
}
