using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class TeachersRepository(
    ApplicationDbContext context) : Repository, ITeachersRepository
{
    public async Task<Teacher?> FindOneAsync(FindOneRepositoryParams parameters)
    {
        query = context.Teachers.AsQueryable();
        ApplyIncludes(parameters.Includes);
        BuildQuery(parameters.Where);
        var entity = await query.FirstOrDefaultAsync();

        return (Teacher?)entity;
    }

    public async Task<IEnumerable<Teacher>> FindManyAsync(FindManyRepositoryParams parameters)
    {
        query = context.Teachers.Include("Year").Include("Unit").Include("Position").Include("Situation").AsNoTracking();
        BuildQuery(parameters.Where);
        BuildOrderBy(parameters.OrderBy);
        ApplyPagination(parameters.Pagination);
        var entities = await query.ToListAsync();

        return entities.Cast<Teacher>();
    }

    public async Task CreateAsync(Teacher entity)
    {
        await context.Teachers.AddAsync(entity);
    }

    public void Update(Teacher entiy)
    {
        context.Teachers.Update(entiy);
    }

    public void Delete(Teacher entiy)
    {
        context.Teachers.Remove(entiy);
    }

    public async Task<int> CountAsync(Entity props)
    {
        query = context.Teachers.AsNoTracking();
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
