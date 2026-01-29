using Assignment.Api.Attributes;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Api.Requests;

public record CreatePreferencesRequest
{
    [RequiredField]
    [StringMaxLength(50)]
    [UniqueField<Preference>(typeof(IPreferencesRepository), typeof(ExistsPreferencesParams))]
    [Display(Name = nameof(Name), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public string? Name { get; set; } = string.Empty;

    public static implicit operator PreferenceProps(CreatePreferencesRequest request)
    {
        return new PreferenceProps
        {
            Name = request.Name,
        };
    }
}

public record UpdatePreferencesRequest
{
    [StringMaxLength(50)]
    [StringMinLength(1)]
    [UniqueField<Preference>(typeof(IPreferencesRepository), typeof(ExclusivePreferencesParams))]
    [Display(Name = nameof(Name), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public string? Name { get; set; } = string.Empty;

    public static implicit operator PreferenceProps(UpdatePreferencesRequest request)
    {
        return new PreferenceProps
        {
            Name = request.Name,
        };
    }
}
