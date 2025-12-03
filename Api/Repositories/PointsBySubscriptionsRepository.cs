using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class PointsBySubscriptionsRepository(
    ApplicationDbContext context) : Repository, IPointsBySubscriptionsRepository
{
    public async Task<PointsBySubscription?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        query = context.PointsBySubscriptions.AsQueryable();
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        var entity = await query.FirstOrDefaultAsync();

        return (PointsBySubscription?)entity;
    }

    public async Task<IEnumerable<PointsBySubscription>> FindManyAsync(FindManyRepositoryParams parameters)
    {
        query = context.PointsBySubscriptions.AsNoTracking();
        BuildQuery(parameters.Where);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        var entities = await query.ToListAsync();

        return entities.Cast<PointsBySubscription>();
    }

    public async Task CreateAsync(PointsBySubscription entity)
    {
        entity.Id = context.PointsBySubscriptions.Last().Id + 1;
        await context.PointsBySubscriptions.AddAsync(entity);
    }

    public async Task CreateManyAsync(IEnumerable<PointsBySubscription> entities)
    {
        var id = context.PointsBySubscriptions.Last().Id + 1;
        foreach (var entity in entities)
        {
            entity.Id = id++;
        }
        await context.PointsBySubscriptions.AddRangeAsync(entities);
    }

    public void Update(PointsBySubscription entiy)
    {
        context.PointsBySubscriptions.Update(entiy);
    }

    public void Delete(PointsBySubscription entiy)
    {
        context.PointsBySubscriptions.Remove(entiy);
    }

    public async Task DeleteManyAsync(Entity props)
    {
        query = context.PointsBySubscriptions.AsNoTracking();
        BuildQuery(props);
        var entities = await query.ToListAsync();
        context.PointsBySubscriptions.RemoveRange(entities.Cast<PointsBySubscription>());
    }

    public async Task<int> CountAsync(Entity props)
    {
        query = context.PointsBySubscriptions.AsNoTracking();
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
