namespace Assignment.Api.Responses;

public record CreatePreferencesResponse
{
    public Guid? Id { get; set; }
}

public record FindManyPreferencesResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
}

public record FindOnePreferencesResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
}
