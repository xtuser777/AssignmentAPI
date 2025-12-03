using Assignment.Api.Entities;

namespace Assignment.Api.Interfaces.Repositories;

public interface ISituationsRepository : IRepository<Situation>
{
}

public class FindManySituationsParams : SituationProps;

public class CountSituationsParams : FindManySituationsParams;

public class ExistsSituationsParams : CountSituationsParams;

public class ExclusiveSituationsParams : ExistsSituationsParams
{
    public int ExcludeId { get; set; }
}

public record OrderBySituationsParams : OrderByParams
{
    public string? Name { get; set; }
}
