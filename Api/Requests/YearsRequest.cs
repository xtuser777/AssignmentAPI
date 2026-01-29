using Assignment.Api.Attributes;
using Assignment.Api.Entities;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Api.Requests;

public record CreateYearsRequest
{
    [RequiredField]
    [Display(Name = nameof(YearId), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public int? YearId { get; set; }

    [RequiredField]
    [StringMaxLength(250)]
    [Display(Name = nameof(Record), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public string? Record { get; set; }

    [RequiredField]
    [StringMaxLength(250)]
    [Display(Name = nameof(Resolution), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public string? Resolution { get; set; }

    [RequiredField]
    [Display(Name = nameof(IsBlocked), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public char? IsBlocked { get; set; }

    public static implicit operator YearProps(CreateYearsRequest request)
        => new()
        {
            YearId = request.YearId,
            Record = request.Record,
            Resolution = request.Resolution,
            IsBlocked = request.IsBlocked,
        };
}

public record UpdateYearsRequest
{
    [RequiredField]
    [StringMaxLength(250)]
    [Display(Name = nameof(Record), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public string? Record { get; set; }

    [StringMinLength(1)]
    [StringMaxLength(250)]
    [Display(Name = nameof(Resolution), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public string? Resolution { get; set; }

    [RequiredField]
    [Display(Name = nameof(IsBlocked), ResourceType = typeof(Resources.DisplayValues.Requests))]
    public char? IsBlocked { get; set; }

    public static implicit operator YearProps(UpdateYearsRequest request)
        => new()
        {
            Record = request.Record,
            Resolution = request.Resolution,
            IsBlocked = request.IsBlocked,
        };
}
