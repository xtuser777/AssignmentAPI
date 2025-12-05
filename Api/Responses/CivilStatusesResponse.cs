namespace Assignment.Api.Responses;

public record CreateCivilStatusesResponse
{
    public int? CivilStatusId { get; set; }
}

public record FindManyCivilStatusesResponse
{
    public int? CivilStatusId { get; set; }
    public string? Name { get; set; }
}

public record FindOneCivilStatusesResponse
{
    public int? CivilStatusId { get; set; }
    public string? Name { get; set; }
}
