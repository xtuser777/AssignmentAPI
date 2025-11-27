using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class PreferencesRepository(
    ApplicationDbContext context) : Repository, IPreferencesRepository
{
    public async Task<Preference?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        query = context.Preferences.AsQueryable();
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        var entity = await query.FirstOrDefaultAsync();

        return (Preference?)entity;
    }

    public async Task<IEnumerable<Preference>> FindManyAsync(FindManyRepositoryParams parameters)
    {
        query = context.Preferences.AsNoTracking();
        BuildQuery(parameters.Where);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        var entities = await query.ToListAsync();

        return entities.Cast<Preference>();
    }

    public async Task CreateAsync(Preference entity)
    {
        await context.Preferences.AddAsync(entity);
    }

    public void Update(Preference entiy)
    {
        context.Preferences.Update(entiy);
    }

    public void Delete(Preference entiy)
    {
        context.Preferences.Remove(entiy);
    }

    public async Task<int> CountAsync(Entity props)
    {
        query = context.Preferences.AsNoTracking();
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
