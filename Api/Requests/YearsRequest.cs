using Assignment.Api.Attributes;
using Assignment.Api.Entities;

namespace Assignment.Api.Requests;

public record CreateYearsRequest
{
    [RequiredField]
    [StringMaxLength(250)]
    public string? Record { get; set; }

    [RequiredField]
    [StringMaxLength(250)]
    public string? Resolution { get; set; }

    [RequiredField]
    [BoolValue]
    public char? IsBlocked { get; set; }

    public static implicit operator YearProps(CreateYearsRequest request)
        => new()
        {
            Record = request.Record,
            Resolution = request.Resolution,
            IsBlocked = request.IsBlocked,
        };
}

public record UpdateYearsRequest
{
    [RequiredField]
    [StringMaxLength(250)]
    public string? Record { get; set; }

    [StringMinLength(1)]
    [StringMaxLength(250)]
    public string? Resolution { get; set; }

    [BoolValue]
    public char? IsBlocked { get; set; }

    public static implicit operator YearProps(UpdateYearsRequest request)
        => new()
        {
            Record = request.Record,
            Resolution = request.Resolution,
            IsBlocked = request.IsBlocked,
        };
}
