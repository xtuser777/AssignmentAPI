using Assignment.Api.Entities;

namespace Assignment.Api.Interfaces.Repositories;

public interface IUsersRolesRepository : IRepository<UserRole>
{
}

public class FindManyUsersRolesParams : UserRoleProps;

public record IncludesUsersRolesParams : IncludesParams
{
    public bool? User { get; set; }
    public bool? Role { get; set; }
}
