using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class PreferencesRepository : Repository<Preference>, IPreferencesRepository
{
    private readonly ApplicationDbContext _context;

    public PreferencesRepository(ApplicationDbContext context)
    {
        _context = context;
        query = context.Preferences.AsQueryable();
    }
    public async Task<Preference?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        var entity = await query.FirstOrDefaultAsync();

        return entity;
    }

    public async Task<IEnumerable<Preference>> FindManyAsync(FindManyRepositoryParams parameters)
    {
        BuildQuery(parameters.Where);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        return await query.ToListAsync();
    }

    public async Task CreateAsync(Preference entity)
    {
        entity.PreferenceId = await GetId(x => x.PreferenceId);
        await _context.Preferences.AddAsync(entity);
    }

    public async Task CreateManyAsync(IEnumerable<Preference> entities)
    {
        await _context.Preferences.AddRangeAsync(entities);
    }

    public void Update(Preference entiy)
    {
        _context.Preferences.Update(entiy);
    }

    public void Delete(Preference entiy)
    {
        _context.Preferences.Remove(entiy);
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
