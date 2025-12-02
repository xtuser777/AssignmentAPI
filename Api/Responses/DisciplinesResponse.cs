namespace Assignment.Api.Responses;

public record CreateDisciplinesResponse
{
    public Guid? Id { get; set; }
}

public record FindManyDisciplinesResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
}

public record FindOneDisciplinesResponse
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
}
