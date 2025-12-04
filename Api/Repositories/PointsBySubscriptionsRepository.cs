using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class PointsBySubscriptionsRepository : Repository<PointsBySubscription>, IPointsBySubscriptionsRepository
{
    private readonly ApplicationDbContext _context;

    public PointsBySubscriptionsRepository(ApplicationDbContext context)
    {
        _context = context;
        query = context.PointsBySubscriptions.AsQueryable();
    }

    public async Task<PointsBySubscription?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<PointsBySubscription>> FindManyAsync(FindManyRepositoryParams parameters)
    {
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        return await query.ToListAsync();
    }

    public async Task CreateAsync(PointsBySubscription entity)
    {
        entity.Id = await GetId();
        await _context.PointsBySubscriptions.AddAsync(entity);
    }

    public async Task CreateManyAsync(IEnumerable<PointsBySubscription> entities)
    {
        var id = await GetId();
        foreach (var entity in entities)
        {
            entity.Id = id++;
        }
        await _context.PointsBySubscriptions.AddRangeAsync(entities);
    }

    public void Update(PointsBySubscription entiy)
    {
        _context.PointsBySubscriptions.Update(entiy);
    }

    public void Delete(PointsBySubscription entiy)
    {
        _context.PointsBySubscriptions.Remove(entiy);
    }

    public async Task DeleteManyAsync(Entity props)
    {
        BuildQuery(props);
        var entities = await query.ToListAsync();
        _context.PointsBySubscriptions.RemoveRange(entities.Cast<PointsBySubscription>());
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
