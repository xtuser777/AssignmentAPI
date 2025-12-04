using Assignment.Api.Entities;
using Assignment.Api.Interfaces.Repositories;

namespace Assignment.Api.Interfaces.Services;

public interface IService<T>
{
    Task<T> FindOneAsync(
        FindOneServiceParams parameters);
    Task<IEnumerable<T>> FindManyAsync(
        FindManyServiceParams parameters);
    Task<PaginationModel?> FindManyPaginationAsync(
        FindManyPaginationServiceParams parameters);
    Task<T> CreateAsync(CreateServiceParams parameters);
    Task UpdateAsync(UpdateServiceParams parameters);
    Task DeleteAsync(DeleteServiceParams parameters);
}

public record FindManyServiceParams
{
    public Entity FindManyProps { get; set; } = null!;
    public OrderByParams OrderByParams { get; set; } = new();
    public IncludesParams? Includes { get; set; }
    public PaginationParams PaginationParams { get; set; } = new();

    public static implicit operator FindManyRepositoryParams(
        FindManyServiceParams parameters)
        => new()
        {
            Where = parameters.FindManyProps,
            OrderBy = parameters.OrderByParams,
            Includes = parameters.Includes,
            Pagination = parameters.PaginationParams,
        };
}

public record FindManyPaginationServiceParams
{
    public Entity CountProps { get; set; } = null!;
    public PaginationParams PaginationParams { get; set; } = new();
}

public record FindOneServiceParams
{
    public int Id { get; set; }
    public IncludesParams? Includes { get; set; }

    public static implicit operator FindOneRepositoryParams(
        FindOneServiceParams parameters)
        => new()
        {
            Where = new() { Id = parameters.Id },
            Includes = parameters.Includes
        };
}

public record CreateServiceParams
{
    public Entity Props { get; set; } = null!;
}

public record UpdateServiceParams
{
    public int Id { get; set; }

    public Entity Props { get; set; } = null!;

    public static implicit operator FindOneServiceParams(
        UpdateServiceParams parameters)
        => new()
        {
            Id = parameters.Id,
        };
}

public record DeleteServiceParams
{
    public int Id { get; set; }

    public static implicit operator FindOneServiceParams(
        DeleteServiceParams parameters)
        => new()
        {
            Id = parameters.Id,
        };
}
