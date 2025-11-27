using Assignment.Api.Entities;

namespace Assignment.Api.Interfaces.Repositories;

public interface IUsersUnitsRepository : IRepository<UserUnit>
{
}

public class FindManyUsersUnitsParams : UserUnitProps;

public class CountUsersUnitsParams : FindManyUsersUnitsParams;

public class ExistsUsersUnitsParams : CountUsersUnitsParams;

public class ExclusiveUsersUnitsParams : ExistsUsersUnitsParams
{
    public Guid ExcludeId { get; set; }
}

public record IncludesUsersUnitsParams : IncludesParams
{
    public bool? User { get; set; }
    public bool? Unit { get; set; }
}
