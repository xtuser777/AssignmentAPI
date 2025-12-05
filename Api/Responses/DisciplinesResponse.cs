namespace Assignment.Api.Responses;

public record CreateDisciplinesResponse
{
    public int? DisciplineId { get; set; }
}

public record FindManyDisciplinesResponse
{
    public int? DisciplineId { get; set; }
    public string? Name { get; set; }
}

public record FindOneDisciplinesResponse
{
    public int? DisciplineId { get; set; }
    public string? Name { get; set; }
}
