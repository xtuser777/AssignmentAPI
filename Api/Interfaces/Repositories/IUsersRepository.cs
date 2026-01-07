using Assignment.Api.Entities;

namespace Assignment.Api.Interfaces.Repositories;

public interface IUsersRepository : IRepository<User>
{
}

public class FindManyUsersParams : UserProps;

public class CountUsersParams : FindManyUsersParams;

public class ExistsUsersParams : CountUsersParams;

public class ExclusiveUsersParams : ExistsUsersParams
{
    public int ExcludeUserId { get; set; }
}

public record OrderByUsersParams : OrderByParams
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Active { get; set; }
}

public record IncludesUsersUsersRolesParams
{
    public bool? Role { get; set; }
}

public record IncludesUsersUsersUnitsParams
{
    public bool? Unit { get; set; }
}

public record IncludesUsersParams : IncludesParams
{
    public IncludesUsersUsersRolesParams? UsersRoles { get; set; }
    public IncludesUsersUsersUnitsParams? UsersUnits { get; set; }
}
