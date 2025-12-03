using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class SituationsRepository(
    ApplicationDbContext context) : Repository, ISituationsRepository
{
    public async Task<Situation?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        query = context.Situations.AsQueryable();
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        var entity = await query.FirstOrDefaultAsync();

        return (Situation?)entity;
    }

    public async Task<IEnumerable<Situation>> FindManyAsync(FindManyRepositoryParams parameters)
    {
        query = context.Situations.AsNoTracking();
        BuildQuery(parameters.Where);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        var entities = await query.ToListAsync();

        return entities.Cast<Situation>();
    }

    public async Task CreateAsync(Situation entity)
    {
        entity.Id = context.Situations.Last().Id + 1;
        await context.Situations.AddAsync(entity);
    }

    public void Update(Situation entiy)
    {
        context.Situations.Update(entiy);
    }

    public void Delete(Situation entiy)
    {
        context.Situations.Remove(entiy);
    }

    public async Task<int> CountAsync(Entity props)
    {
        query = context.Situations.AsNoTracking();
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
