using Assignment.Api.Entities;

namespace Assignment.Api.Interfaces.Services;

public interface IImportsService : IService<Import>
{
    Task<bool> ExistsAsync(ExistsServiceParams parameters);
}

public record ExistsServiceParams
{
    public Entity Where { get; init; } = new();
}
