using Assignment.Api.Entities;

namespace Assignment.Api.Interfaces.Repositories;

public interface IYearsRepository : IRepository<Year>
{
}

public class FindManyYearsParams : YearProps;

public class CountYearParams : FindManyYearsParams;

public class ExistsYearParams : CountYearParams;

public class ExclusiveYearParams : ExistsYearParams
{
    public int ExcludeId { get; set; }
}

public record OrderByYearsParams: OrderByParams
{
    public string? Value { get; set; }
    public string? Record { get; set; }
    public string? Resolution { get; set; }
    public string? IsBlocked { get; set; }
}
