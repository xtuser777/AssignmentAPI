namespace Assignment.Api.Responses;

public record CreateSituationsResponse
{
    public Guid? Id { get; set; }
}

public record FindManySituationsResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
}

public record FindOneSituationsResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
}
