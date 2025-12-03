namespace Assignment.Api.Responses;

public record CreateCivilStatusesResponse
{
    public int? Id { get; set; }
}

public record FindManyCivilStatusesResponse
{
    public int? Id { get; set; }
    public string? Name { get; set; }
}

public record FindOneCivilStatusesResponse
{
    public int? Id { get; set; }
    public string? Name { get; set; }
}
