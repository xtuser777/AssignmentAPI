namespace Assignment.Api.Responses;

public record CreateYearsResponse
{
    public Guid? Id { get; set; }
}

public record FindManyYearsResponse
{
    public Guid? Id { get; set; }
    public int? Value { get; set; }
    public string? Record { get; set; }
    public string? Resolution { get; set; }
    public bool? IsBlocked { get; set; }
}

public record FindOneYearsResponse
{
    public Guid? Id { get; set; }
    public int? Value { get; set; }
    public string? Record { get; set; }
    public string? Resolution { get; set; }
    public bool? IsBlocked { get; set; }
}
