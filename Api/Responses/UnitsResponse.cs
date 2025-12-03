namespace Assignment.Api.Responses;

public record CreateUnitsResponse
{
    public int? Id { get; set; }
}

public record FindManyUnitsResponse
{
    public int? Id { get; set; }
    public string? Name { get; set; } = string.Empty;
}

public record FindOneUnitsResponse
{
    public int? Id { get; set; }
    public string? Name { get; set; } = string.Empty;
}
