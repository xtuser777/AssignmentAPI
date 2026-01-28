using Assignment.Api.Attributes;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Api.Requests;

public record CreateImportsRequest
{
    [RequiredField]
    [Connection<Import>(typeof(IYearsRepository), typeof(ExistsYearParams))]
    [Display(Name = nameof(YearId), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public required int YearId { get; init; }

    [RequiredField]
    [DateValue]
    [Display(Name = nameof(Date), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public required DateOnly Date { get; init; }

    [RequiredField]
    [TimeValue]
    [Display(Name = nameof(Time), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public required TimeOnly Time { get; init; }

    [RequiredField]
    [StringMaxLength(10)]
    [Display(Name = nameof(Type), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public required string Type { get; init; }

    [RequiredField]
    [Connection<User>(typeof(IUsersRepository), typeof(ExistsUsersParams))]
    [Display(Name = nameof(Login), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public required string Login { get; init; }

    public static implicit operator ImportProps(CreateImportsRequest request)
    {
        return new ImportProps
        {
            YearId = request.YearId,
            Date = request.Date,
            Time = request.Time,
            Type = request.Type,
            Login = request.Login,
        };
    }
}
