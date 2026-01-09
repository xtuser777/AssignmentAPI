using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class RolesRepository(ApplicationDbContext context) : Repository<Role>, IRolesRepository
{

    public async Task CreateAsync(Role entity)
    {
        await context.Roles.AddAsync(entity);
    }

    public async Task<IEnumerable<Role>> FindManyAsync(FindManyRepositoryParams @params)
    {
        query = context.Roles.AsNoTracking();
        ApplyIncludes(@params.Includes);
        BuildQuery(@params.Where);
        BuildOrderBy(@params.OrderBy);
        ApplyPagination(@params.Pagination);
        return await query.ToListAsync();
    }

    public Task<Role?> FindOneAsync(FindOneRepositoryParams @params)
    {
        query = context.Roles.AsQueryable();
        ApplyIncludes(@params.Includes);
        BuildQuery(@params.Where);
        return query.SingleOrDefaultAsync();
    }

    public async Task<int> CountAsync(Entity parameters)
    {
        query = context.Roles.AsNoTracking();
        BuildQuery(parameters);
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(Entity parameters)
    {
        query = context.Roles.AsNoTracking();
        var count = await CountAsync(parameters);
        return count > 0;
    }
}
