using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class TitlesRepository : Repository<Title>, ITitlesRepository
{
    private readonly ApplicationDbContext _context;

    public TitlesRepository(ApplicationDbContext context)
    {
        _context = context;
        query = context.Titles.AsQueryable();
    }

    public async Task<Title?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Title>> FindManyAsync(FindManyRepositoryParams parameters)
    {
        BuildQuery(parameters.Where);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Title entity)
    {
        entity.TitleId = await GetId(x => x.TitleId);
        await _context.Titles.AddAsync(entity);
    }

    public async Task CreateManyAsync(IEnumerable<Title> entities)
    {
        await _context.Titles.AddRangeAsync(entities);
    }

    public void Update(Title entiy)
    {
        _context.Titles.Update(entiy);
    }

    public void Delete(Title entiy)
    {
        _context.Titles.Remove(entiy);
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
