namespace Assignment.Api.Responses;

public record CreateTitlesResponse
{
    public int? YearId { get; set; }
    public int? TitleId { get; set; }
}

public record FindManyTitlesResponse
{
    public int? YearId { get; set; }
    public int? TitleId { get; set; }
    public string? Description { get; set; }
    public string? Alias { get; set; }
    public decimal? Weight { get; set; }
    public decimal? Max { get; set; }
    public int? Order { get; set; }
    public char? Type { get; set; }
    public char? Active { get; set; }
}

public record FindOneTitlesResponse
{
    public int? YearId { get; set; }
    public int? TitleId { get; set; }
    public string? Description { get; set; }
    public string? Alias { get; set; }
    public decimal? Weight { get; set; }
    public decimal? Max { get; set; }
    public int? Order { get; set; }
    public char? Type { get; set; }
    public char? Active { get; set; }
}
