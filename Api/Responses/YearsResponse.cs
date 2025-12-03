namespace Assignment.Api.Responses;

public record CreateYearsResponse
{
    public int? Id { get; set; }
}

public record FindManyYearsResponse
{
    public int? Id { get; set; }
    public string? Record { get; set; }
    public string? Resolution { get; set; }
    public bool? IsBlocked { get; set; }
}

public record FindOneYearsResponse
{
    public int? Id { get; set; }
    public string? Record { get; set; }
    public string? Resolution { get; set; }
    public bool? IsBlocked { get; set; }
}
