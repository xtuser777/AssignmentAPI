using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class UsersUnitsRepository : Repository<UserUnit>, IUsersUnitsRepository
{
    private readonly ApplicationDbContext _context;

    public UsersUnitsRepository(ApplicationDbContext context)
    {
        _context = context;
        query = context.UsersUnits.AsQueryable();
    }

    public async Task<UserUnit?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<UserUnit>> FindManyAsync(FindManyRepositoryParams parameters)
    {
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        var entities = await query.ToListAsync();

        return entities.Cast<UserUnit>();
    }

    public async Task CreateAsync(UserUnit entity)
    {
        await _context.UsersUnits.AddAsync(entity);
    }

    public async Task CreateManyAsync(IEnumerable<UserUnit> entities)
    {
        await _context.UsersUnits.AddRangeAsync(entities);
    }

    public void Update(UserUnit entiy)
    {
        _context.UsersUnits.Update(entiy);
    }

    public void Delete(UserUnit entiy)
    {
        _context.UsersUnits.Remove(entiy);
    }

    public async Task DeleteManyAsync(Entity props)
    {
        BuildQuery(props);
        var entities = await query.ToListAsync();
        _context.UsersUnits.RemoveRange(entities.Cast<UserUnit>());
    }

    public async Task<int> CountAsync(Entity props)
    {
        BuildQuery(props);
        return await query.CountAsync();
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
