namespace Assignment.Api.Responses;

public record CreateUsersResponse
{
    public Guid? Id { get; set; }
}

public record FindManyUsersResponse
{
    public Guid? Id { get; set; }
    public string? Username { get; set; } = string.Empty;
    public string? Name { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public bool? IsActive { get; set; }
    public TranslatableField? Role { get; set; }
}

public record FindOneUsersUsersUnitsResponse
{
    public Guid? Id { get; set; }
    public Guid? UserId { get; set; }
    public Guid? UnitId { get; set; }
}

public record FindOneUsersResponse
{
    public Guid? Id { get; set; }
    public string? Username { get; set; } = string.Empty;
    public string? Name { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public bool? IsActive { get; set; }
    public TranslatableField? Role { get; set; }
    public IEnumerable<FindOneUsersUsersUnitsResponse>? UsersUnits { get; set; }
}
