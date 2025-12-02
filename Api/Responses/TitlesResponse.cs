namespace Assignment.Api.Responses;

public record CreateTitlesResponse
{
    public Guid? Id { get; set; }
}

public record FindManyTitlesResponse
{
    public Guid? Id { get; set; }
    public string? Description { get; set; }
    public string? Alias { get; set; }
    public decimal? Weight { get; set; }
    public decimal? Max { get; set; }
    public int? Order { get; set; }
    public char? Type { get; set; }
    public bool? IsActive { get; set; }
    public Guid? YearId { get; set; }
}

public record FindOneTitlesResponse
{
    public Guid? Id { get; set; }
    public string? Description { get; set; }
    public string? Alias { get; set; }
    public decimal? Weight { get; set; }
    public decimal? Max { get; set; }
    public int? Order { get; set; }
    public char? Type { get; set; }
    public bool? IsActive { get; set; }
    public Guid? YearId { get; set; }
    public FindOneTitlesYearResponse? Year { get; set; }
}

public record FindOneTitlesYearResponse
{
    public Guid? Id { get; set; }
    public int? Value { get; set; }
}
