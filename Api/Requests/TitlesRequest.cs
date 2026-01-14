using Assignment.Api.Attributes;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Api.Requests;

public record CreateTitlesRequest
{
    [RequiredField]
    [StringMaxLength(255)]
    [UniqueField<Title>(typeof(ITitlesRepository), typeof(ExistsTitlesParams))]
    [Display(Name = nameof(Description), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public string? Description { get; set; }

    [RequiredField]
    [StringMaxLength(10)]
    [Display(Name = nameof(Alias), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public string? Alias { get; set; }

    [RequiredField]
    [Display(Name = nameof(Weight), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public decimal? Weight { get; set; }

    [RequiredField]
    [Display(Name = nameof(Max), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public decimal? Max { get; set; }

    [RequiredField]
    [Display(Name = nameof(Order), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public int? Order { get; set; }

    [RequiredField]
    [Display(Name = nameof(Type), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public char? Type { get; set; }

    [RequiredField]
    [Display(Name = nameof(Active), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public char? Active { get; set; }

    [RequiredField]
    [Display(Name = nameof(YearId), ResourceType = typeof(Resources.DisplayValues.Requests))]
    [Connection<Year>(typeof(IYearsRepository), typeof(ExistsYearParams))]
    public int? YearId { get; set; }

    public static implicit operator TitleProps(CreateTitlesRequest request)
    {
        return new TitleProps
        {
            Description = request.Description,
            Alias = request.Alias,
            Weight = request.Weight,
            Max = request.Max,
            Order = request.Order,
            Type = request.Type,
            Active = request.Active,
            YearId = request.YearId,
        };
    }
}

public record UpdateTitlesRequest
{
    [StringMinLength(1)]
    [StringMaxLength(255)]
    [UniqueField<Title>(typeof(ITitlesRepository), typeof(ExclusiveTitlesParams))]
    [Display(Name = nameof(Description), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public string? Description { get; set; }

    [StringMinLength(1)]
    [StringMaxLength(10)]
    [Display(Name = nameof(Alias), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public string? Alias { get; set; }

    [Range(0, 100)]
    [Display(Name = nameof(Weight), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public decimal? Weight { get; set; }

    [Range(0, 100)]
    [Display(Name = nameof(Max), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public decimal? Max { get; set; }

    [Range(0, 100)]
    [Display(Name = nameof(Order), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public int? Order { get; set; }

    [Display(Name = nameof(Type), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public char? Type { get; set; }

    [Display(Name = nameof(Active), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public char? Active { get; set; }

    [Connection<Year>(typeof(IYearsRepository), typeof(ExclusiveYearParams))]
    [Display(Name = nameof(YearId), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public int? YearId { get; set; }

    public static implicit operator TitleProps(UpdateTitlesRequest request)
    {
        return new TitleProps
        {
            Description = request.Description,
            Alias = request.Alias,
            Weight = request.Weight,
            Max = request.Max,
            Order = request.Order,
            Type = request.Type,
            Active = request.Active,
            YearId = request.YearId,
        };
    }
}

public record ImportTitlesRequest
{
    [RequiredField]
    [Connection<Year>(typeof(IYearsRepository), typeof(ExistsYearParams))]
    public int? YearId { get; set; }

    public static implicit operator int(ImportTitlesRequest request)
    {
        return request.YearId ?? 0;
    }
}
