using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class ClassificationsRepository : Repository<Classification>, IClassificationsRepository
{
    private readonly ApplicationDbContext _context;

    public ClassificationsRepository(ApplicationDbContext context)
    {
        _context = context;
        query = context.Classifications.AsQueryable();
    }

    public async Task<Classification?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Classification>> FindManyAsync(FindManyRepositoryParams parameters)
    {
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Classification entity)
    {
        entity.Id = await GetId();
        await _context.Classifications.AddAsync(entity);
    }

    public async Task CreateManyAsync(IEnumerable<Classification> entities)
    {
        var id = await GetId();
        foreach (var entity in entities)
        {
            entity.Id ??= id++;
        }
        await _context.Classifications.AddRangeAsync(entities);
    }

    public void Update(Classification entiy)
    {
        _context.Classifications.Update(entiy);
    }

    public void Delete(Classification entiy)
    {
        _context.Classifications.Remove(entiy);
    }

    public async Task<int> CountAsync(Entity props)
    {
        BuildQuery(props);
        return await query.CountAsync();
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
