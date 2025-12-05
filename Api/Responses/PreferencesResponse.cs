namespace Assignment.Api.Responses;

public record CreatePreferencesResponse
{
    public int? PreferenceId { get; set; }
}

public record FindManyPreferencesResponse
{
    public int? PreferenceId { get; set; }
    public string? Name { get; set; }
}

public record FindOnePreferencesResponse
{
    public int? PreferenceId { get; set; }
    public string? Name { get; set; }
}
