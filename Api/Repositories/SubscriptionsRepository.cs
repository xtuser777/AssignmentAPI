using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class SubscriptionsRepository(
    ApplicationDbContext context) : Repository, ISubscriptionsRepository
{
    public async Task<Subscription?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        query = context.Subscriptions.AsQueryable();
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        var entity = await query.FirstOrDefaultAsync();

        return (Subscription?)entity;
    }

    public async Task<IEnumerable<Subscription>> FindManyAsync(FindManyRepositoryParams parameters)
    {
        query = context.Subscriptions.Include("Year").Include("Teacher:Unit").Include("Preference").AsNoTracking();
        BuildQuery(parameters.Where);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        var entities = await query.ToListAsync();

        return entities.Cast<Subscription>();
    }

    public async Task CreateAsync(Subscription entity)
    {
        await context.Subscriptions.AddAsync(entity);
    }

    public void Update(Subscription entiy)
    {
        context.Subscriptions.Update(entiy);
    }

    public void Delete(Subscription entiy)
    {
        context.Subscriptions.Remove(entiy);
    }

    public async Task<int> CountAsync(Entity props)
    {
        query = context.Subscriptions.AsNoTracking();
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
