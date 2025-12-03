using Assignment.Api.Entities;

namespace Assignment.Api.Interfaces.Repositories;

public interface ITitlesRepository : IRepository<Title>
{
}

public class FindManyTitlesParams : TitleProps;

public class CountTitlesParams : FindManyTitlesParams;

public class ExistsTitlesParams : CountTitlesParams;

public class ExclusiveTitlesParams : ExistsTitlesParams
{
    public int ExcludeId { get; set; }
}

public record OrderByTitlesParams : OrderByParams
{
    public string? Description { get; set; }
    public string? Alias { get; set; }
    public string? Weight { get; set; }
    public string? Max { get; set; }
    public string? Order { get; set; }
    public string? Type { get; set; }
    public string? IsActive { get; set; }
    public string? Year { get; set; }
}

public record IncludesTitlesParams : IncludesParams
{
    public bool? Year { get; set; }
}
