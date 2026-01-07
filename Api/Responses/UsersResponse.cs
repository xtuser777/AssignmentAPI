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
    public int? RoleId { get; set; }
    public string? RoleDescription { get; set; } = string.Empty;
}

public record FindOneUsersUsersUnitsResponse
{
    public string? UserLogin { get; set; }
    public int? UnitId { get; set; }
    public string? UnitName { get; set; }
}

public record FindOneUsersUsersRolesResponse
{
    public string? Username { get; set; }
    public int? RoleId { get; set; }
    public string? RoleDescription { get; set; } = string.Empty;
}

public record FindOneUsersResponse
{
    public string? Username { get; set; } = string.Empty;
    public string? Name { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public char? Active { get; set; }
    public int? RoleId { get; set; }
    public FindOneUsersUsersRolesResponse? UserRole { get; set; }
    public IEnumerable<FindOneUsersUsersUnitsResponse>? UsersUnits { get; set; }
}
