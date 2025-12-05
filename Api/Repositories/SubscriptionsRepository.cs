using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class SubscriptionsRepository : Repository<Subscription>, ISubscriptionsRepository
{
    private readonly ApplicationDbContext _context;

    public SubscriptionsRepository(ApplicationDbContext context)
    {
        _context = context;
        query = context.Subscriptions.AsQueryable();
    }

    public async Task<Subscription?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Subscription>> FindManyAsync(FindManyRepositoryParams parameters)
    {
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Subscription entity)
    {
        await _context.Subscriptions.AddAsync(entity);
    }

    public async Task CreateManyAsync(IEnumerable<Subscription> entities)
    {
        await _context.Subscriptions.AddRangeAsync(entities);
    }

    public void Update(Subscription entiy)
    {
        _context.Subscriptions.Update(entiy);
    }

    public void Delete(Subscription entiy)
    {
        _context.Subscriptions.Remove(entiy);
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
