namespace Assignment.Api.Responses;

public record CreateUnitsResponse
{
    public int? UnitId { get; set; }
}

public record FindManyUnitsResponse
{
    public int? UnitId { get; set; }
    public string? Name { get; set; } = string.Empty;
}

public record FindOneUnitsResponse
{
    public int? UnitId { get; set; }
    public string? Name { get; set; } = string.Empty;
}
