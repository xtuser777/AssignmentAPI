using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class ImportsRepository(
    ApplicationDbContext context) : Repository<Import>, IImportsRepository
{
    public async Task<Import?> FindOneAsync(FindOneRepositoryParams @params)
    {
        query = context.Imports.AsQueryable();
        ApplyIncludes(@params.Includes);
        BuildQuery(@params.Where);
        return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Import>> FindManyAsync(FindManyRepositoryParams @params)
    {
        query = context.Imports.AsNoTracking();
        ApplyIncludes(@params.Includes);
        BuildQuery(@params.Where);
        BuildOrderBy(@params.OrderBy);
        ApplyPagination(@params.Pagination);
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Import entity)
    {
        await context.Imports.AddAsync(entity);
    }

    public void Update(Import entity)
    {
        context.Imports.Update(entity);
    }

    public void Delete(Import entity)
    {
        context.Imports.Remove(entity);
    }

    public async Task<int> CountAsync(Entity parameters)
    {
        query = context.Imports.AsNoTracking();
        BuildQuery(parameters);
        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(Entity parameters)
    {
        query = context.Imports.AsNoTracking();
        var count = await CountAsync(parameters);
        return count > 0;
    }
}
