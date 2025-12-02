namespace Assignment.Api.Responses;

public record CreatePositionsResponse
{
    public Guid? Id { get; set; }
}

public record FindManyPositionsResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public bool? IsActive { get; set; }
}

public record FindOnePositionsResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public bool? IsActive { get; set; }
}
