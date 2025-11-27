using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class UsersRepository(
    ApplicationDbContext context) : Repository, IUsersRepository
{
    public async Task<User?> FindOneAsync(FindOneRepositoryParams @params)
    {
        query = context.Users.AsQueryable();
        ApplyIncludes(@params.Includes);
        BuildQuery(@params.Where);
        var entity = await query.FirstOrDefaultAsync();

        return (User?)entity;
    }

    public async Task<IEnumerable<User>> FindManyAsync(FindManyRepositoryParams @params)
    {
        query = context.Users.AsNoTracking();
        BuildQuery(@params.Where);
        BuildOrderBy(@params.OrderBy);
        ApplyPagination(@params.Pagination);
        var entities = await query.ToListAsync();

        return entities.Cast<User>();
    }

    public async Task CreateAsync(User entity)
    {
        await context.Users.AddAsync(entity);
    }

    public void Update(User entity) 
    {
        context.Users.Update(entity);
    }

    public void Delete(User entity)
    {
        context.Users.Remove(entity);
    }

    public void SoftDelete(User entity)
    {
        entity.IsActive = false;
        context.Users.Update(entity);
    }

    public async Task<int> CountAsync(Entity props)
    {
        query = context.Users.AsNoTracking();
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
