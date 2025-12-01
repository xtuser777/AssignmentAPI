namespace Assignment.Api.Responses;

public record CreateUnitsResponse
{
    public Guid? Id { get; set; }
}

public record FindManyUnitsResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; } = string.Empty;
}

public record FindOneUnitsResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; } = string.Empty;
}
