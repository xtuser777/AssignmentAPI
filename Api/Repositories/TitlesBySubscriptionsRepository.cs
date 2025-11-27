using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class TitlesBySubscriptionsRepository(
    ApplicationDbContext context) : Repository, ITitlesBySubscriptionsRepository
{
    public async Task<TitleBySubscription?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        query = context.TitlesBySubscriptions.AsQueryable();
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        var entity = await query.FirstOrDefaultAsync();

        return (TitleBySubscription?)entity;
    }

    public async Task<IEnumerable<TitleBySubscription>> FindManyAsync(FindManyRepositoryParams parameters)
    {
        query = context.TitlesBySubscriptions.AsNoTracking();
        BuildQuery(parameters.Where);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        var entities = await query.ToListAsync();

        return entities.Cast<TitleBySubscription>();
    }

    public async Task CreateAsync(TitleBySubscription entity)
    {
        await context.TitlesBySubscriptions.AddAsync(entity);
    }

    public async Task CreateManyAsync(IEnumerable<TitleBySubscription> entities)
    {
        await context.TitlesBySubscriptions.AddRangeAsync(entities);
    }

    public void Update(TitleBySubscription entiy)
    {
        context.TitlesBySubscriptions.Update(entiy);
    }

    public void Delete(TitleBySubscription entiy)
    {
        context.TitlesBySubscriptions.Remove(entiy);
    }

    public async Task DeleteManyAsync(Entity props)
    {
        query = context.TitlesBySubscriptions.AsNoTracking();
        BuildQuery(props);
        var entities = await query.ToListAsync();
        context.TitlesBySubscriptions.RemoveRange(entities.Cast<TitleBySubscription>());
    }

    public async Task<int> CountAsync(Entity props)
    {
        query = context.TitlesBySubscriptions.AsNoTracking();
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
