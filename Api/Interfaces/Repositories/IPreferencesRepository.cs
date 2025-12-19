using Assignment.Api.Entities;

namespace Assignment.Api.Interfaces.Repositories;

public interface IPreferencesRepository : IRepository<Preference>
{
}

public class FindManyPreferencesParams : PreferenceProps;

public class CountPreferencesParams : FindManyPreferencesParams;

public class ExistsPreferencesParams : CountPreferencesParams;

public class ExclusivePreferencesParams : CountPreferencesParams
{
    public int ExcludePreferenceId { get; set; }
}

public record OrderByPreferencesParams : OrderByParams
{
    public string? Name { get; set; }
}
