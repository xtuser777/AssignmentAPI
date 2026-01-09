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

public record FindOneUsersUserUnitResponse
{
    public string? UserLogin { get; set; }
    public int? UnitId { get; set; }
    public string? UnitName { get; set; }
}

public record FindOneUsersUserRoleResponse
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
    public int? UnitId { get; set; }
    public FindOneUsersUserRoleResponse? UserRole { get; set; }
    public FindOneUsersUserUnitResponse? UserUnit { get; set; }
}
