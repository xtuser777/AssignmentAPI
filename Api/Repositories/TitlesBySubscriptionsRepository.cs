using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class TitlesBySubscriptionsRepository : Repository<TitleBySubscription>, ITitlesBySubscriptionsRepository
{
    private readonly ApplicationDbContext _context;

    public TitlesBySubscriptionsRepository(ApplicationDbContext context)
    {
        _context = context;
        query = context.TitlesBySubscriptions.AsQueryable();
    }

    public async Task<TitleBySubscription?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<TitleBySubscription>> FindManyAsync(FindManyRepositoryParams parameters)
    {
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        return await query.ToListAsync();
    }

    public async Task CreateAsync(TitleBySubscription entity)
    {
        await _context.TitlesBySubscriptions.AddAsync(entity);
    }

    public async Task CreateManyAsync(IEnumerable<TitleBySubscription> entities)
    {
        await _context.TitlesBySubscriptions.AddRangeAsync(entities);
    }

    public void Update(TitleBySubscription entiy)
    {
        _context.TitlesBySubscriptions.Update(entiy);
    }

    public void Delete(TitleBySubscription entiy)
    {
        _context.TitlesBySubscriptions.Remove(entiy);
    }

    public async Task DeleteManyAsync(Entity props)
    {
        BuildQuery(props);
        var entities = await query.ToListAsync();
        _context.TitlesBySubscriptions.RemoveRange(entities.Cast<TitleBySubscription>());
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
