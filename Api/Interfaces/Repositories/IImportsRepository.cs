using Assignment.Api.Entities;

namespace Assignment.Api.Interfaces.Repositories;

public interface IImportsRepository : IRepository<Import>
{
}

public class FindManyImportsParams : ImportProps;

public class CountImportsParams : FindManyImportsParams;

public class ExistsImportsParams : CountImportsParams;

public record OrderByImportsParams : OrderByParams
{
    public string? YearId { get; set; }
    public string? Date { get; set; }
    public string? Time { get; set; }
    public string? Type { get; set; }
    public string? Login { get; set; }
}