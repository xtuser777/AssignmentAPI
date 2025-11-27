using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class TeatchersRepository(
    ApplicationDbContext context) : Repository, ITeatchersRepository
{
    public async Task<Teatcher?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        query = context.Teatchers.AsQueryable();
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        var entity = await query.FirstOrDefaultAsync();

        return (Teatcher?)entity;
    }

    public async Task<IEnumerable<Teatcher>> FindManyAsync(FindManyRepositoryParams parameters)
    {
        query = context.Teatchers.AsNoTracking();
        BuildQuery(parameters.Where);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        var entities = await query.ToListAsync();

        return entities.Cast<Teatcher>();
    }

    public async Task CreateAsync(Teatcher entity)
    {
        await context.Teatchers.AddAsync(entity);
    }

    public void Update(Teatcher entiy)
    {
        context.Teatchers.Update(entiy);
    }

    public void Delete(Teatcher entiy)
    {
        context.Teatchers.Remove(entiy);
    }

    public async Task<int> CountAsync(Entity props)
    {
        query = context.Teatchers.AsNoTracking();
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
