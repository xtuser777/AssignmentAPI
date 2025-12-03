using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class CivilStatusesRepository(
    ApplicationDbContext context) : Repository, ICivilStatusesRepository
{
    public async Task<CivilStatus?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        query = context.CivilStatuses.AsQueryable();
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        var entity = await query.FirstOrDefaultAsync();

        return (CivilStatus?)entity;
    }

    public async Task<IEnumerable<CivilStatus>> FindManyAsync(FindManyRepositoryParams parameters)
    {
        query = context.CivilStatuses.AsNoTracking();
        BuildQuery(parameters.Where);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        var entities = await query.ToListAsync();

        return entities.Cast<CivilStatus>();
    }

    public async Task CreateAsync(CivilStatus entity)
    {
        entity.Id = context.CivilStatuses.Last().Id + 1;
        await context.CivilStatuses.AddAsync(entity);
    }

    public void Update(CivilStatus entiy)
    {
        context.CivilStatuses.Update(entiy);
    }

    public void Delete(CivilStatus entiy)
    {
        context.CivilStatuses.Remove(entiy);
    }

    public async Task<int> CountAsync(Entity props)
    {
        query = context.CivilStatuses.AsNoTracking();
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
