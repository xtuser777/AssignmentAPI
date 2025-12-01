using Assignment.Api.Attributes;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;

namespace Assignment.Api.Requests;

public record CreateUnitsRequest
{
    [RequiredField]
    [StringMaxLength(100)]
    [UniqueField<Unit>(typeof(IUnitsRepository), typeof(ExistsUnitsParams))]
    public string? Name { get; set; } = string.Empty;

    public static implicit operator UnitProps(CreateUnitsRequest request)
    {
        return new UnitProps
        {
            Name = request.Name,
        };
    }
}

public record UpdateUnitsRequest
{
    [StringMaxLength(100)]
    [StringMinLength(1)]
    [UniqueField<Unit>(typeof(IUnitsRepository), typeof(ExclusiveUnitsParams))]
    public string? Name { get; set; } = string.Empty;

    public static implicit operator UnitProps(UpdateUnitsRequest request)
    {
        return new UnitProps
        {
            Name = request.Name,
        };
    }
}
