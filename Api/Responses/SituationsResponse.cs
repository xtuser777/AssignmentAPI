namespace Assignment.Api.Responses;

public record CreateSituationsResponse
{
    public int? SituationId { get; set; }
}

public record FindManySituationsResponse
{
    public int? SituationId { get; set; }
    public string? Name { get; set; }
}

public record FindOneSituationsResponse
{
    public int? SituationId { get; set; }
    public string? Name { get; set; }
}
