using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class ImportsRepository : Repository<Import>, IImportsRepository
{
    private readonly ApplicationDbContext _context;

    public ImportsRepository(ApplicationDbContext context)
    {
        _context = context;
        query = context.Imports.AsNoTracking();
    }

    public async Task<Import?> FindOneAsync(FindOneRepositoryParams @params)
    {
        query = _context.Imports.AsQueryable();
        ApplyIncludes(@params.Includes);
        BuildQuery(@params.Where);
        return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Import>> FindManyAsync(FindManyRepositoryParams @params)
    {
        ApplyIncludes(@params.Includes);
        BuildQuery(@params.Where);
        BuildOrderBy(@params.OrderBy);
        ApplyPagination(@params.Pagination);
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Import entity)
    {
        await _context.Imports.AddAsync(entity);
    }

    public void Update(Import entity)
    {
        _context.Imports.Update(entity);
    }

    public void Delete(Import entity)
    {
        _context.Imports.Remove(entity);
    }

    public async Task<int> CountAsync(Entity parameters)
    {
        BuildQuery(parameters);
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(Entity parameters)
    {
        var count = await CountAsync(parameters);
        return count > 0;
    }
}
