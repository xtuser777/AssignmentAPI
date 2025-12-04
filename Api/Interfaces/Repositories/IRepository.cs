using Assignment.Api.Entities;

namespace Assignment.Api.Interfaces.Repositories;

public interface IRepository<T>
{
    Task<T?> FindOneAsync(FindOneRepositoryParams @params);
    Task<IEnumerable<T>> FindManyAsync(
        FindManyRepositoryParams @params);
    Task CreateAsync(T entity);
    public Task CreateManyAsync(IEnumerable<T> entities)
    {
        return Task.CompletedTask;
    }
    public Task DeleteManyAsync(Entity props)
    { return Task.CompletedTask; }
    public void Update(T entity) { }
    public void Delete(T entity) { }
    public void SoftDelete(T entity) { }
    Task<int> CountAsync(Entity props)
    {
        return Task.FromResult(0);
    }
    public Task<bool> ExistsAsync(Entity props)
    {
        return Task.FromResult(true);
    }
    public Task<bool> ExclusiveAsync(Entity props)
    {
        return Task.FromResult(true);
    }
}

public record IncludesParams();

public record OrderByParams();

public record PaginationParams
{
    public int? Page { get; set; } = null;
    public int? Size { get; set; } = null;

    public void Deconstruct(out int? page, out int? size)
    {
        page = Page;
        size = Size;
    }
}

public record FindManyRepositoryParams
{
    public Entity Where { get; set; } = new();
    public OrderByParams? OrderBy { get; set; }
    public IncludesParams? Includes { get; set; }
    public PaginationParams? Pagination { get; set; }
}

public record FindOneRepositoryParams
{
    public Entity Where { get; set; } = new();
    public IncludesParams? Includes { get; set; }
}

