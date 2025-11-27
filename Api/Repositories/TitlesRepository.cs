using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class TitlesRepository(
    ApplicationDbContext context) : Repository, ITitlesRepository
{
    public async Task<Title?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        query = context.Titles.AsQueryable();
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        var entity = await query.FirstOrDefaultAsync();

        return (Title?)entity;
    }

    public async Task<IEnumerable<Title>> FindManyAsync(FindManyRepositoryParams parameters)
    {
        query = context.Titles.AsNoTracking();
        BuildQuery(parameters.Where);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        var entities = await query.ToListAsync();

        return entities.Cast<Title>();
    }

    public async Task CreateAsync(Title entity)
    {
        await context.Titles.AddAsync(entity);
    }

    public void Update(Title entiy)
    {
        context.Titles.Update(entiy);
    }

    public void Delete(Title entiy)
    {
        context.Titles.Remove(entiy);
    }

    public async Task<int> CountAsync(Entity props)
    {
        query = context.Titles.AsNoTracking();
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
