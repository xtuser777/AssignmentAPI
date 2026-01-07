using Assignment.Api.Entities;

namespace Assignment.Api.Interfaces.Repositories;

public interface IRolesRepository : IRepository<Role>
{
}

public class FindManyRolesParams : RoleProps;

public class CountRolesParams : FindManyRolesParams;

public record OrderByRolesParams : OrderByParams
{
    public string? Description { get; set; }
}

