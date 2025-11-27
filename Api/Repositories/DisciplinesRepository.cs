using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class DisciplinesRepository(
    ApplicationDbContext context) : Repository, IDisciplinesRepository
{
    public async Task<Discipline?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        query = context.Disciplines.AsQueryable();
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        var entity = await query.FirstOrDefaultAsync();

        return (Discipline?)entity;
    }

    public async Task<IEnumerable<Discipline>> FindManyAsync(FindManyRepositoryParams parameters)
    {
        query = context.Disciplines.AsNoTracking();
        BuildQuery(parameters.Where);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        var entities = await query.ToListAsync();

        return entities.Cast<Discipline>();
    }

    public async Task CreateAsync(Discipline entity)
    {
        await context.Disciplines.AddAsync(entity);
    }

    public void Update(Discipline entiy)
    {
        context.Disciplines.Update(entiy);
    }

    public void Delete(Discipline entiy)
    {
        context.Disciplines.Remove(entiy);
    }

    public async Task<int> CountAsync(Entity props)
    {
        query = context.Disciplines.AsNoTracking();
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
