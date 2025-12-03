namespace Assignment.Api.Responses;

public record CreatePreferencesResponse
{
    public int? Id { get; set; }
}

public record FindManyPreferencesResponse
{
    public int? Id { get; set; }
    public string? Name { get; set; }
}

public record FindOnePreferencesResponse
{
    public int? Id { get; set; }
    public string? Name { get; set; }
}
