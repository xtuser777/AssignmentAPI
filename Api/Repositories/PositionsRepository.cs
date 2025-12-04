using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class PositionsRepository : Repository<Position>, IPositionsRepository
{
    private readonly ApplicationDbContext _context;

    public PositionsRepository(ApplicationDbContext context)
    {
        _context = context;
        query = context.Positions.AsQueryable();
    }

    public async Task<Position?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Position>> FindManyAsync(FindManyRepositoryParams parameters)
    {
        BuildQuery(parameters.Where);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Position entity)
    {
        entity.Id = await GetId();
        await _context.Positions.AddAsync(entity);
    }

    public async Task CreateManyAsync(IEnumerable<Position> entities)
    {
        var id = await GetId();
        foreach (var entity in entities)
        {
            entity.Id ??= id++;
        }
        await _context.Positions.AddRangeAsync(entities);
    }

    public void Update(Position entiy)
    {
        _context.Positions.Update(entiy);
    }

    public void Delete(Position entiy)
    {
        _context.Positions.Remove(entiy);
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
