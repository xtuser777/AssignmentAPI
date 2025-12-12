using Assignment.Api.Attributes;
using Assignment.Api.Entities;

namespace Assignment.Api.Requests;

public record CreateYearsRequest
{
    [RequiredField]
    public int? YearId { get; set; }

    [RequiredField]
    [StringMaxLength(250)]
    public string? Record { get; set; }

    [RequiredField]
    [StringMaxLength(250)]
    public string? Resolution { get; set; }

    [RequiredField]
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
    public string? Record { get; set; }

    [StringMinLength(1)]
    [StringMaxLength(250)]
    public string? Resolution { get; set; }

    [RequiredField]
    public char? IsBlocked { get; set; }

    public static implicit operator YearProps(UpdateYearsRequest request)
        => new()
        {
            Record = request.Record,
            Resolution = request.Resolution,
            IsBlocked = request.IsBlocked,
        };
}
