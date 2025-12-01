using Assignment.Api.Attributes;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;

namespace Assignment.Api.Requests;

public record CreateCivilStatusesRequest
{
    [RequiredField]
    [StringMaxLength(50)]
    [UniqueField<CivilStatus>(typeof(ICivilStatusesRepository), typeof(ExistsCivilStatusesParams))]
    public string? Name { get; set; } = string.Empty;

    public static implicit operator CivilStatusProps(CreateCivilStatusesRequest request)
    {
        return new CivilStatusProps
        {
            Name = request.Name,
        };
    }
}

public record UpdateCivilStatusesRequest
{
    [StringMaxLength(50)]
    [StringMinLength(1)]
    [UniqueField<CivilStatus>(typeof(ICivilStatusesRepository), typeof(ExclusiveCivilStatusesParams))]
    public string? Name { get; set; } = string.Empty;

    public static implicit operator CivilStatusProps(UpdateCivilStatusesRequest request)
    {
        return new CivilStatusProps
        {
            Name = request.Name,
        };
    }
}
