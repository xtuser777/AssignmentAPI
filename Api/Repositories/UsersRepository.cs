using Assignment.Api.Contexts;
using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Api.Repositories;

public class UsersRepository : Repository<User>, IUsersRepository
{
    private readonly ApplicationDbContext _context;

    public UsersRepository(ApplicationDbContext context)
    {
        _context = context;
        query = context.Users.AsQueryable();
    }

    public async Task<User?> FindOneAsync(FindOneRepositoryParams @params)
    {
        ApplyIncludes(@params.Includes);
        BuildQuery(@params.Where);
        return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<User>> FindManyAsync(FindManyRepositoryParams @params)
    {
        BuildQuery(@params.Where);
        BuildOrderBy(@params.OrderBy);
        ApplyPagination(@params.Pagination);
        return await query.ToListAsync();
    }

    public async Task CreateAsync(User entity)
    {
        await _context.Users.AddAsync(entity);
    }

    public async Task CreateManyAsync(IEnumerable<User> entities)
    {
        await _context.Users.AddRangeAsync(entities);
    }

    public void Update(User entity) 
    {
        _context.Users.Update(entity);
    }

    public void Delete(User entity)
    {
        _context.Users.Remove(entity);
    }

    public void SoftDelete(User entity)
    {
        entity.Active = 'N';
        _context.Users.Update(entity);
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
