using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class DisciplinesRepository : Repository<Discipline>, IDisciplinesRepository
{
    private readonly ApplicationDbContext _context;

    public DisciplinesRepository(ApplicationDbContext context)
    {
        _context = context;
        query = context.Disciplines.AsQueryable();
    }
    public async Task<Discipline?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        var entity = await query.FirstOrDefaultAsync();

        return entity;
    }

    public async Task<IEnumerable<Discipline>> FindManyAsync(FindManyRepositoryParams parameters)
    {
        BuildQuery(parameters.Where);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Discipline entity)
    {
        entity.Id = await GetId();
        await _context.Disciplines.AddAsync(entity);
    }

    public async Task CreateManyAsync(IEnumerable<Discipline> entities)
    {
        var id = await GetId();
        foreach (var entity in entities)
        {
            entity.Id ??= id++;
        }
        await _context.Disciplines.AddRangeAsync(entities);
    }

    public void Update(Discipline entiy)
    {
        _context.Disciplines.Update(entiy);
    }

    public void Delete(Discipline entiy)
    {
        _context.Disciplines.Remove(entiy);
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
