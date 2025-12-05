namespace Assignment.Api.Responses;

public record CreatePositionsResponse
{
    public int? PositionId { get; set; }
}

public record FindManyPositionsResponse
{
    public int? PositionId { get; set; }
    public string? Name { get; set; }
    public char? Active { get; set; }
}

public record FindOnePositionsResponse
{
    public int? PositionId { get; set; }
    public string? Name { get; set; }
    public char? Active { get; set; }
}
