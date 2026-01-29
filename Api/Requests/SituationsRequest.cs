using Assignment.Api.Attributes;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Api.Requests;

public record CreateSituationsRequest
{
    [RequiredField]
    [StringMaxLength(50)]
    [UniqueField<Situation>(typeof(ISituationsRepository), typeof(ExistsSituationsParams))]
    [Display(Name = nameof(Name), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public string? Name { get; set; } = string.Empty;

    public static implicit operator SituationProps(CreateSituationsRequest request)
    {
        return new SituationProps
        {
            Name = request.Name,
        };
    }
}

public record UpdateSituationsRequest
{
    [StringMaxLength(50)]
    [StringMinLength(1)]
    [UniqueField<Situation>(typeof(ISituationsRepository), typeof(ExclusiveSituationsParams))]
    [Display(Name = nameof(Name), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public string? Name { get; set; } = string.Empty;

    public static implicit operator SituationProps(UpdateSituationsRequest request)
    {
        return new SituationProps
        {
            Name = request.Name,
        };
    }
}
