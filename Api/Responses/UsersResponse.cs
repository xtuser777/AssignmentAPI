namespace Assignment.Api.Responses;

public record CreateUsersResponse
{
    public int? Id { get; set; }
}

public record FindManyUsersResponse
{
    public int? Id { get; set; }
    public string? Username { get; set; } = string.Empty;
    public string? Name { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public bool? IsActive { get; set; }
    public TranslatableField? Role { get; set; }
}

public record FindOneUsersUsersUnitsResponse
{
    public int? Id { get; set; }
    public string? UserLogin { get; set; }
    public int? UnitId { get; set; }
}

public record FindOneUsersResponse
{
    public int? Id { get; set; }
    public string? Username { get; set; } = string.Empty;
    public string? Name { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public bool? IsActive { get; set; }
    public TranslatableField? Role { get; set; }
    public IEnumerable<FindOneUsersUsersUnitsResponse>? UsersUnits { get; set; }
}
