using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class UnitsRepository : Repository<Unit>, IUnitsRepository
{
    private readonly ApplicationDbContext _context;

    public UnitsRepository(ApplicationDbContext context)
    {
        _context = context;
        query = context.Units.AsQueryable();
    }

    public async Task<Unit?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Unit>> FindManyAsync(FindManyRepositoryParams parameters)
    {
        BuildQuery(parameters.Where);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Unit entity)
    {
        entity.Id = await GetId();
        await _context.Units.AddAsync(entity);
    }

    public async Task CreateManyAsync(IEnumerable<Unit> entities)
    {
        var id = await GetId();
        foreach (var entity in entities)
        {
            entity.Id ??= id++;
        }
        await _context.Units.AddRangeAsync(entities);
    }

    public void Update(Unit entiy)
    {
        _context.Units.Update(entiy);
    }

    public void Delete(Unit entiy)
    {
        _context.Units.Remove(entiy);
    }

    public async Task<int> CountAsync(Entity props)
    {
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
