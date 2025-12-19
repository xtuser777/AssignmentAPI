using Assignment.Api.Entities;

namespace Assignment.Api.Interfaces.Repositories;

public interface ICivilStatusesRepository : IRepository<CivilStatus>
{
}

public class FindManyCivilStatusesParams : CivilStatusProps;

public class CountCivilStatusesParams : FindManyCivilStatusesParams;

public class ExistsCivilStatusesParams : CountCivilStatusesParams;

public class ExclusiveCivilStatusesParams : CountCivilStatusesParams
{
    public int ExcludeCivilStatusId { get; set; }
}

public record OrderByCivilStatusesParams : OrderByParams
{
    public string? Name { get; set; }
}
