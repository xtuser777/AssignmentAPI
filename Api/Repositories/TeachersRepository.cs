using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class TeachersRepository : Repository<Teacher>, ITeachersRepository
{
    private readonly ApplicationDbContext _context;

    public TeachersRepository(ApplicationDbContext context)
    {
        _context = context;
        query = context.Teachers.AsQueryable();
    }

    public async Task<Teacher?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Teacher>> FindManyAsync(FindManyRepositoryParams parameters)
    {
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Teacher entity)
    {
        await _context.Teachers.AddAsync(entity);
    }

    public async Task CreateManyAsync(IEnumerable<Teacher> entities)
    {
        await _context.Teachers.AddRangeAsync(entities);
    }

    public void Update(Teacher entiy)
    {
        _context.Teachers.Update(entiy);
    }

    public void Delete(Teacher entiy)
    {
        _context.Teachers.Remove(entiy);
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
