using Assignment.Api.Entities;

namespace Assignment.Api.Interfaces.Repositories;

public interface IPositionsRepository : IRepository<Position>
{
}

public class FindManyPositionsParams : PositionProps;

public class CountPositionsParams : FindManyPositionsParams;

public class ExistsPositionsParams : CountPositionsParams;

public class ExclusivePositionsParams : CountPositionsParams
{
    public int ExcludeId { get; set; }
}

public record OrderByPositionsParams : OrderByParams
{
    public string? Name { get; set; }
    public string? Active { get; set; }
}
