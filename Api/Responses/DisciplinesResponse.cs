namespace Assignment.Api.Responses;

public record CreateDisciplinesResponse
{
    public int? Id { get; set; }
}

public record FindManyDisciplinesResponse
{
    public int? Id { get; set; }
    public string? Name { get; set; }
}

public record FindOneDisciplinesResponse
{
    public int? Id { get; set; }
    public string? Name { get; set; }
}
