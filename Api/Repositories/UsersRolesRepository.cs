using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class UsersRolesRepository(
    ApplicationDbContext context) : Repository<UserRole>, IUsersRolesRepository
{
    public async Task CreateAsync(UserRole entity)
    {
        await context.UsersRoles.AddAsync(entity);
    }
    public async Task CreateManyAsync(IEnumerable<UserRole> entities)
    {
        await context.UsersRoles.AddRangeAsync(entities);
    }

    public async Task<IEnumerable<UserRole>> FindManyAsync(FindManyRepositoryParams @params)
    {
        ApplyIncludes(@params.Includes);
        BuildQuery(@params.Where);
        return await query.ToListAsync();
    }

    public async Task<UserRole?> FindOneAsync(FindOneRepositoryParams @params)
    {
        ApplyIncludes(@params.Includes);
        BuildQuery(@params.Where);
        return await query.SingleOrDefaultAsync();
    }

    public async Task DeleteManyAsync(FindManyUsersRolesParams parameters)
    {
        BuildQuery(parameters);
        var usersRoles = await query.ToListAsync();
        context.UsersRoles.RemoveRange(usersRoles);
    }
}
