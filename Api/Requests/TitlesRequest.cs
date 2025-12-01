using Assignment.Api.Attributes;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Api.Requests;

public record CreateTitlesRequest
{
    [RequiredField]
    [StringMaxLength(255)]
    public string? Description { get; set; }

    [RequiredField]
    [StringMaxLength(10)]
    public string? Alias { get; set; }

    [RequiredField]
    public decimal? Weight { get; set; }

    [RequiredField]
    public decimal? Max { get; set; }

    [RequiredField]
    public int? Order { get; set; }

    [RequiredField]
    public char? Type { get; set; }

    [RequiredField]
    public bool? IsActive { get; set; }

    [RequiredField]
    [Connection<Year>(typeof(IYearsRepository))]
    public Guid? YearId { get; set; }

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
            IsActive = request.IsActive,
            YearId = request.YearId,
        };
    }
}

public record UpdateTitlesRequest
{
    [StringMinLength(1)]
    [StringMaxLength(255)]
    public string? Description { get; set; }

    [StringMinLength(1)]
    [StringMaxLength(10)]
    public string? Alias { get; set; }

    [Range(0, 100)]
    public decimal? Weight { get; set; }

    [Range(0, 100)]
    public decimal? Max { get; set; }

    [Range(0, 100)]
    public int? Order { get; set; }

    public char? Type { get; set; }

    [BoolValue]
    public bool? IsActive { get; set; }

    [GuidValue]
    [Connection<Year>(typeof(IYearsRepository))]
    public Guid? YearId { get; set; }

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
            IsActive = request.IsActive,
            YearId = request.YearId,
        };
    }
}
