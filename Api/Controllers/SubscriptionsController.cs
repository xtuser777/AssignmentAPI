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
public class SubscriptionsController(
    ISubscriptionsView subscriptionsView,
    ISubscriptionsService subscriptionsService
) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> IndexAsync(
        [AsParameters] IndexSubscriptionsParams parameters)
    {
        var subscriptions = await subscriptionsService.FindManyAsync(parameters);
        var pagination = await subscriptionsService.FindManyPaginationAsync(parameters);
        var data = subscriptionsView.FindMany(subscriptions);

        return Ok(new
        {
            Data = data,
            Pagination = pagination
        });
    }

    [HttpGet("{subscriptionId:int}")]
    public async Task<IActionResult> ShowAsync(
        [AsParameters] ShowSubscriptionsParams parameters)
    {
        var subscription = await subscriptionsService.FindOneAsync(parameters);
        var data = subscriptionsView.FindOne(subscription);

        return Ok(new { Data = data });
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [AsParameters] CreateSubscriptionsParams parameters)
    {
        var subscription = await subscriptionsService.CreateAsync(parameters);
        var data = subscriptionsView.Create(subscription);

        return Created($"subscriptions/{subscription.SubscriptionId}", new { Data = data });
    }

    [HttpPut("{subscriptionId:int}")]
    public async Task<IActionResult> UpdateAsync(
        [AsParameters] UpdateSubscriptionsParams parameters)
    {
        await subscriptionsService.UpdateAsync(parameters);

        return NoContent();
    }

    [HttpDelete("{subscriptionId:int}")]
    public async Task<IActionResult> DeleteAsync(
        [AsParameters] DeleteSubscriptionsParams parameters)
    {
        await subscriptionsService.DeleteAsync(parameters);

        return NoContent();
    }
}


public record IndexSubscriptionsParams : PaginationParams
{
    public int? SubscriptionId { get; set; }
    public int? YearId { get; set; }
    public int? TeacherId { get; set; }
    public int? PreferenceId { get; set; }

    [FromHeader(Name = "X-Order-By-Year-Id")]
    public string? OrderByYearId { get; set; }
    [FromHeader(Name = "X-Order-By-Teacher")]
    public string? OrderByTeacher { get; set; }
    [FromHeader(Name = "X-Order-By-Preference")]
    public string? OrderByPreference { get; set; }

    public static implicit operator FindManyServiceParams(
        IndexSubscriptionsParams parameters)
        => new()
        {
            FindManyProps = new FindManySubscriptionsParams
            {
                SubscriptionId = parameters.SubscriptionId,
                YearId = parameters.YearId,
                TeacherId = parameters.TeacherId,
                PreferenceId = parameters.PreferenceId,
            },
            OrderByParams = new OrderBySubscriptionsParams
            {
                YearId = parameters.OrderByYearId,
                Teacher = parameters.OrderByTeacher,
                Preference = parameters.OrderByPreference,
            },
            Includes = new IncludesSubscriptionsParams()
            {
                Teacher = new IncludesSubscriptionsTeacherParams
                {
                    Unit = true,
                },
                Preference = true,
            },
            PaginationParams = parameters,
        };

    public static implicit operator FindManyPaginationServiceParams(
        IndexSubscriptionsParams parameters)
        => new()
        {
            CountProps = new CountSubscriptionsParams
            {
                SubscriptionId = parameters.SubscriptionId,
                YearId = parameters.YearId,
                TeacherId = parameters.TeacherId,
                PreferenceId = parameters.PreferenceId,
            },
            PaginationParams = parameters,
        };
}

public record ShowSubscriptionsParams
{
    [FromRoute(Name = "subscriptionId")]
    public int SubscriptionId { get; set; }

    [FromRoute]
    public bool? IncludeTeacher { get; set; } = true;

    [FromRoute]
    public bool? IncludePreference { get; set; } = true;

    public static implicit operator FindOneServiceParams(
        ShowSubscriptionsParams parameters)
        => new()
        {
            Where = new FindManySubscriptionsParams
            {
                SubscriptionId = parameters.SubscriptionId,
            },
            Includes = new IncludesSubscriptionsParams
            {
                Teacher = new IncludesSubscriptionsTeacherParams
                {
                    Unit = parameters.IncludeTeacher
                },
                Preference = parameters.IncludePreference,
                Titles = true,
            },
        };
}

public record CreateSubscriptionsParams
{
    [FromBody]
    public CreateSubscriptionsRequest? Body { get; set; }

    public static implicit operator CreateServiceParams(
        CreateSubscriptionsParams parameters)
        => new()
        {
            Props = parameters.Body!,
        };
}

public record UpdateSubscriptionsParams
{
    [FromRoute(Name = "subscriptionId")]
    public int SubscriptionId { get; set; }

    [FromBody]
    public UpdateSubscriptionsRequest? Body { get; set; }

    public static implicit operator UpdateServiceParams(
        UpdateSubscriptionsParams parameters)
        => new()
        {
            Where = new FindManySubscriptionsParams
            {
                SubscriptionId = parameters.SubscriptionId
            },
            Props = parameters.Body!,
        };
}

public record DeleteSubscriptionsParams
{
    [FromRoute(Name = "subscriptionId")]
    public int SubscriptionId { get; set; }

    public static implicit operator DeleteServiceParams(
        DeleteSubscriptionsParams parameters)
        => new()
        {
            Where = new FindManySubscriptionsParams
            {
                SubscriptionId = parameters.SubscriptionId
            },
        };
}