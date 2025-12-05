using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class SituationsRepository : Repository<Situation>, ISituationsRepository
{
    private readonly ApplicationDbContext _context;

    public SituationsRepository(ApplicationDbContext context)
    {
        _context = context;
        query = context.Situations.AsQueryable();
    }
    public async Task<Situation?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Situation>> FindManyAsync(FindManyRepositoryParams parameters)
    {
        BuildQuery(parameters.Where);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Situation entity)
    {
        await _context.Situations.AddAsync(entity);
    }

    public async Task CreateManyAsync(IEnumerable<Situation> entities)
    {
        await _context.Situations.AddRangeAsync(entities);
    }

    public void Update(Situation entiy)
    {
        _context.Situations.Update(entiy);
    }

    public void Delete(Situation entiy)
    {
        _context.Situations.Remove(entiy);
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
