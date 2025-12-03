using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class PositionsRepository(
    ApplicationDbContext context) : Repository, IPositionsRepository
{
    public async Task<Position?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        query = context.Positions.AsQueryable();
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        var entity = await query.FirstOrDefaultAsync();

        return (Position?)entity;
    }

    public async Task<IEnumerable<Position>> FindManyAsync(FindManyRepositoryParams parameters)
    {
        query = context.Positions.AsNoTracking();
        BuildQuery(parameters.Where);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        var entities = await query.ToListAsync();

        return entities.Cast<Position>();
    }

    public async Task CreateAsync(Position entity)
    {
        entity.Id = context.Positions.Last().Id + 1;
        await context.Positions.AddAsync(entity);
    }

    public void Update(Position entiy)
    {
        context.Positions.Update(entiy);
    }

    public void Delete(Position entiy)
    {
        context.Positions.Remove(entiy);
    }

    public async Task<int> CountAsync(Entity props)
    {
        query = context.Positions.AsNoTracking();
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
