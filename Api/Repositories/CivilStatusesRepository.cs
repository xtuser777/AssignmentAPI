using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class CivilStatusesRepository : Repository<CivilStatus>, ICivilStatusesRepository
{
    private readonly ApplicationDbContext _context;

    public CivilStatusesRepository(ApplicationDbContext context) 
    {
        _context = context;
        query = context.CivilStatuses.AsQueryable();
    }

    public async Task<CivilStatus?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        var entity = await query.FirstOrDefaultAsync();

        return entity;
    }

    public async Task<IEnumerable<CivilStatus>> FindManyAsync(FindManyRepositoryParams parameters)
    {
        BuildQuery(parameters.Where);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        return await query.ToListAsync();
    }

    public async Task CreateAsync(CivilStatus entity)
    {
        entity.Id = await GetId();
        await _context.CivilStatuses.AddAsync(entity);
    }

    public async Task CreateManyAsync(IEnumerable<CivilStatus> entities)
    {
        var id = await GetId();
        foreach (var entity in entities)
        {
            entity.Id ??= id++;
        }
        await _context.CivilStatuses.AddRangeAsync(entities);
    }

    public void Update(CivilStatus entiy)
    {
        _context.CivilStatuses.Update(entiy);
    }

    public void Delete(CivilStatus entiy)
    {
        _context.CivilStatuses.Remove(entiy);
    }

    public async Task<int> CountAsync(Entity props)
    {
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
