namespace Assignment.Api.Responses;

public record CreateSituationsResponse
{
    public int? Id { get; set; }
}

public record FindManySituationsResponse
{
    public int? Id { get; set; }
    public string? Name { get; set; }
}

public record FindOneSituationsResponse
{
    public int? Id { get; set; }
    public string? Name { get; set; }
}
