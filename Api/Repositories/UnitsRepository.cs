using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class UnitsRepository(
    ApplicationDbContext context) : Repository, IUnitsRepository
{
    public async Task<Unit?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        query = context.Units.AsQueryable();
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        var entity = await query.FirstOrDefaultAsync();

        return (Unit?)entity;
    }

    public async Task<IEnumerable<Unit>> FindManyAsync(FindManyRepositoryParams parameters)
    {
        query = context.Units.AsNoTracking();
        BuildQuery(parameters.Where);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        var entities = await query.ToListAsync();

        return entities.Cast<Unit>();
    }

    public async Task CreateAsync(Unit entity)
    {
        entity.Id = ((await context.Units.OrderBy(x => x.Id).LastOrDefaultAsync())?.Id ?? 0) + 1;
        await context.Units.AddAsync(entity);
    }

    public async Task CreateManyAsync(IEnumerable<Unit> entities)
    {
        var id = ((await context.Units.OrderBy(x => x.Id).LastOrDefaultAsync())?.Id ?? 0) + 1;
        foreach (var entity in entities)
        {
            entity.Id ??= id++;
        }
        await context.Units.AddRangeAsync(entities);
    }

    public void Update(Unit entiy)
    {
        context.Units.Update(entiy);
    }

    public void Delete(Unit entiy)
    {
        context.Units.Remove(entiy);
    }

    public async Task<int> CountAsync(Entity props)
    {
        query = context.Units.AsNoTracking();
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
