using Assignment.Api.Entities;

namespace Assignment.Api.Interfaces.Repositories;

public interface IUnitsRepository : IRepository<Unit>
{
}

public class FindManyUnitsParams : UnitProps;

public class CountUnitsParams : FindManyUnitsParams;

public class ExistsUnitsParams : CountUnitsParams;

public class ExclusiveUnitsParams : ExistsUnitsParams
{
    public int ExcludeUnitId { get; set; }
}

public record OrderByUnitsParams : OrderByParams
{
    public string? Name { get; set; }
}
