namespace Assignment.Api.Responses;

public record CreateCivilStatusesResponse
{
    public Guid? Id { get; set; }
}

public record FindManyCivilStatusesResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
}

public record FindOneCivilStatusesResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
}
