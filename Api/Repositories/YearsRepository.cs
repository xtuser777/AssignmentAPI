using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class YearsRepository(
    ApplicationDbContext context) : Repository, IYearsRepository
{
    public async Task<Year?> FindOneAsync(FindOneRepositoryParams @params)
    {
        query = context.Years.AsQueryable();
        ApplyIncludes(@params.Includes);
        BuildQuery(@params.Where);
        Year? year = (Year?)await query.FirstOrDefaultAsync();

        return year;
    }

    public async Task<IEnumerable<Year>> FindManyAsync(FindManyRepositoryParams @params)
    {
        query = context.Years.AsNoTracking();
        BuildQuery(@params.Where);
        BuildOrderBy(@params.OrderBy);
        ApplyPagination(@params.Pagination);

        return (await query.ToListAsync()).Cast<Year>(); 
    }

    public async Task CreateAsync(Year entity)
    {
        entity.Id = context.Years.OrderBy(x => x.Id).Last().Id + 1;
        await context.Years.AddAsync(entity);
    }

    public async Task CreateManyAsync(IEnumerable<Year> entities)
    {
        var id = ((await context.Years.OrderBy(x => x.Id).LastOrDefaultAsync())?.Id ?? 0) + 1;
        foreach (var entity in entities)
        {
            entity.Id ??= id++;
        }
        await context.Years.AddRangeAsync(entities);
    }

    public void Update(Year entity)
    {
        context.Years.Update(entity);
    }

    public void Delete(Year entity)
    {
        context.Years.Remove(entity);
    }

    public async Task<int> CountAsync(Entity props)
    {
        query = context.Years.AsNoTracking();
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
        query = context.Years.AsNoTracking();
        BuildQuery(props);

        var count = await query.CountAsync();

        return count > 0;
    }
}
