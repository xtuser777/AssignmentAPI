using Assignment.Api.Attributes;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Api.Requests;

public record CreatePositionsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [UniqueField<Position>(typeof(IPositionsRepository), typeof(ExistsPositionsParams))]
    [Display(Name = nameof(Name), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public string? Name { get; set; } = string.Empty;

    [RequiredField]
    [Display(Name = nameof(Active), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public char? Active { get; set; }

    public static implicit operator PositionProps(CreatePositionsRequest request)
    {
        return new PositionProps
        {
            Name = request.Name,
            Active = request.Active,
        };
    }
}

public record UpdatePositionsRequest
{
    [StringMaxLength(100)]
    [StringMinLength(1)]
    [UniqueField<Position>(typeof(IPositionsRepository), typeof(ExclusivePositionsParams))]
    [Display(Name = nameof(Name), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public string? Name { get; set; } = string.Empty;

    public char? Active { get; set; }

    public static implicit operator PositionProps(UpdatePositionsRequest request)
    {
        return new PositionProps
        {
            Name = request.Name,
            Active = request.Active,
        };
    }
}
