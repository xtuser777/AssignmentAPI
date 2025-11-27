using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class ClassificationsRepository(
    ApplicationDbContext context) : Repository, IClassificationsRepository
{
    public async Task<Classification?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        query = context.Classifications.AsQueryable();
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        var entity = await query.FirstOrDefaultAsync();

        return (Classification?)entity;
    }

    public async Task<IEnumerable<Classification>> FindManyAsync(FindManyRepositoryParams parameters)
    {
        query = context.Classifications.AsNoTracking();
        BuildQuery(parameters.Where);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        var entities = await query.ToListAsync();

        return entities.Cast<Classification>();
    }

    public async Task CreateAsync(Classification entity)
    {
        await context.Classifications.AddAsync(entity);
    }

    public void Update(Classification entiy)
    {
        context.Classifications.Update(entiy);
    }

    public void Delete(Classification entiy)
    {
        context.Classifications.Remove(entiy);
    }

    public async Task<int> CountAsync(Entity props)
    {
        query = context.Classifications.AsNoTracking();
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
