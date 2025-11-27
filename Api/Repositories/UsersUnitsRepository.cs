using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class UsersUnitsRepository(
    ApplicationDbContext context) : Repository, IUsersUnitsRepository
{
    public async Task<UserUnit?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        query = context.UsersUnits.AsQueryable();
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        var entity = await query.FirstOrDefaultAsync();

        return (UserUnit?)entity;
    }

    public async Task<IEnumerable<UserUnit>> FindManyAsync(FindManyRepositoryParams parameters)
    {
        query = context.UsersUnits.AsNoTracking();
        BuildQuery(parameters.Where);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        var entities = await query.ToListAsync();

        return entities.Cast<UserUnit>();
    }

    public async Task CreateAsync(UserUnit entity)
    {
        await context.UsersUnits.AddAsync(entity);
    }

    public async Task CreateManyAsync(IEnumerable<UserUnit> entities)
    {
        await context.UsersUnits.AddRangeAsync(entities);
    }

    public void Update(UserUnit entiy)
    {
        context.UsersUnits.Update(entiy);
    }

    public void Delete(UserUnit entiy)
    {
        context.UsersUnits.Remove(entiy);
    }

    public async Task DeleteManyAsync(Entity props)
    {
        query = context.UsersUnits.AsNoTracking();
        BuildQuery(props);
        var entities = await query.ToListAsync();
        context.UsersUnits.RemoveRange(entities.Cast<UserUnit>());
    }

    public async Task<int> CountAsync(Entity props)
    {
        query = context.UsersUnits.AsNoTracking();
        BuildQuery(props);
        var count = await query.CountAsync();

        return count;
    }

    public async Task<bool> ExistsAsync(Entity props)
    {
        var count = await CountAsync(props);

        return count > 0;
    }

    public async Task<bool> ExclusiveAsync(Entity props)
    {
        var count = await CountAsync(props);

        return count > 0;
    }
}
