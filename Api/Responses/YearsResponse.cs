namespace Assignment.Api.Responses;

public record CreateYearsResponse
{
    public int? YearId { get; set; }
}

public record FindManyYearsResponse
{
    public int? YearId { get; set; }
    public string? Record { get; set; }
    public string? Resolution { get; set; }
    public char? IsBlocked { get; set; }
}

public record FindOneYearsResponse
{
    public int? YearId { get; set; }
    public string? Record { get; set; }
    public string? Resolution { get; set; }
    public char? IsBlocked { get; set; }
}
