using Assignment.Api.Attributes;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Api.Requests;

public record CreateDisciplinesRequest
{
    [RequiredField]
    [StringMaxLength(50)]
    [UniqueField<Discipline>(typeof(IDisciplinesRepository), typeof(ExistsDisciplinesParams))]
    [Display(Name = nameof(Name), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public string? Name { get; set; } = string.Empty;

    public static implicit operator DisciplineProps(CreateDisciplinesRequest request)
    {
        return new DisciplineProps
        {
            Name = request.Name,
        };
    }
}

public record UpdateDisciplinesRequest
{
    [StringMaxLength(50)]
    [StringMinLength(1)]
    [UniqueField<Discipline>(typeof(IDisciplinesRepository), typeof(ExclusiveDisciplinesParams))]
    [Display(Name = nameof(Name), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public string? Name { get; set; } = string.Empty;

    public static implicit operator DisciplineProps(UpdateDisciplinesRequest request)
    {
        return new DisciplineProps
        {
            Name = request.Name,
        };
    }
}
