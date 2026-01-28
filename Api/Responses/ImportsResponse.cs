namespace Assignment.Api.Responses;

public record CreateImportsResponse
{
    public int? ImportId { get; set; }
    public int? YearId { get; set; }
}

public record FindOneImportsResponse
{
    public int? ImportId { get; set; }
    public int? YearId { get; set; }
    public DateOnly? Date { get; set; }
    public TimeOnly? Time { get; set; }
    public string? Type { get; set; }
    public string? Login { get; set; }
}

public record FindManyImportsResponse
{
    public int? ImportId { get; set; }
    public int? YearId { get; set; }
    public DateOnly? Date { get; set; }
    public TimeOnly? Time { get; set; }
    public string? Type { get; set; }
    public string? Login { get; set; }
}
