using Assignment.Api.Attributes;
using Assignment.Api.Entities;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Api.Requests;

public record CreateYearsRequest
{
    [RequiredField]
    [Range(2016, 2030)]
    public int? Value { get; set; }

    [RequiredField]
    [StringMaxLength(250)]
    public string? Record { get; set; }

    [RequiredField]
    [StringMaxLength(250)]
    public string? Resolution { get; set; }

    [RequiredField]
    [BoolValue]
    public bool? IsBlocked { get; set; }

    public static implicit operator YearProps(CreateYearsRequest request)
        => new()
        {
            Value = request.Value,
            Record = request.Record,
            Resolution = request.Resolution,
            IsBlocked = request.IsBlocked,
        };
}

public record UpdateYearsRequest
{
    [Range(2016, 2030)]
    public int? Value { get; set; }

    [RequiredField]
    [StringMaxLength(250)]
    public string? Record { get; set; }

    [StringMinLength(1)]
    [StringMaxLength(250)]
    public string? Resolution { get; set; }

    [BoolValue]
    public bool? IsBlocked { get; set; }

    public static implicit operator YearProps(UpdateYearsRequest request)
        => new()
        {
            Value = request.Value,
            Record = request.Record,
            Resolution = request.Resolution,
            IsBlocked = request.IsBlocked,
        };
}
