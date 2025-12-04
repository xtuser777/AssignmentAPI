using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class YearsRepository : Repository<Year>, IYearsRepository
{
    private readonly ApplicationDbContext _context;

    public YearsRepository(ApplicationDbContext context)
    {
        _context = context;
        query = context.Years.AsQueryable();
    }

    public async Task<Year?> FindOneAsync(FindOneRepositoryParams @params)
    {
        ApplyIncludes(@params.Includes);
        BuildQuery(@params.Where);
        return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Year>> FindManyAsync(FindManyRepositoryParams @params)
    {
        BuildQuery(@params.Where);
        BuildOrderBy(@params.OrderBy);
        ApplyPagination(@params.Pagination);

        return await query.ToListAsync(); 
    }

    public async Task CreateAsync(Year entity)
    {
        entity.Id = await GetId();
        await _context.Years.AddAsync(entity);
    }

    public async Task CreateManyAsync(IEnumerable<Year> entities)
    {
        var id = await GetId();
        foreach (var entity in entities)
        {
            entity.Id ??= id++;
        }
        await _context.Years.AddRangeAsync(entities);
    }

    public void Update(Year entity)
    {
        _context.Years.Update(entity);
    }

    public void Delete(Year entity)
    {
        _context.Years.Remove(entity);
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
