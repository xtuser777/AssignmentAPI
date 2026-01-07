namespace Assignment.Api.Responses;

public record FindManyRolesResponse
{
    public int? RoleId { get; set; }
    public string? Description { get; set; }
}

public record FindOneRolesResponse
{
    public int? RoleId { get; set; }
    public string? Description { get; set; }
}
