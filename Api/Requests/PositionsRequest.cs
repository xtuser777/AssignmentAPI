using Assignment.Api.Attributes;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;

namespace Assignment.Api.Requests;

public record CreatePositionsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [UniqueField<Position>(typeof(IPositionsRepository), typeof(ExistsPositionsParams))]
    public string? Name { get; set; } = string.Empty;

    [RequiredField]
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
