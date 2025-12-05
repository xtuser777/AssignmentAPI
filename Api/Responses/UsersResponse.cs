namespace Assignment.Api.Responses;

public record CreateUsersResponse
{
    public string? Username { get; set; }
}

public record FindManyUsersResponse
{
    public string? Username { get; set; } = string.Empty;
    public string? Name { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public char? Active { get; set; }
    public TranslatableField? Role { get; set; }
}

public record FindOneUsersUsersUnitsResponse
{
    public string? UserLogin { get; set; }
    public int? UnitId { get; set; }
}

public record FindOneUsersResponse
{
    public string? Username { get; set; } = string.Empty;
    public string? Name { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public char? Active { get; set; }
    public TranslatableField? Role { get; set; }
    public IEnumerable<FindOneUsersUsersUnitsResponse>? UsersUnits { get; set; }
}
