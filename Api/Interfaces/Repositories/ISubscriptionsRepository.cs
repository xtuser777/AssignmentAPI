using Assignment.Api.Entities;

namespace Assignment.Api.Interfaces.Repositories;

public interface ISubscriptionsRepository : IRepository<Subscription>
{
}

public class FindManySubscriptionsParams : SubscriptionProps;

public class CountSubscriptionsParams : FindManySubscriptionsParams;

public class ExistsSubscriptionsParams : CountSubscriptionsParams;

public record OrderBySubscriptionsParams : OrderByParams
{
    public string? Year { get; set; }
    public string? Teatcher { get; set; }
    public string? Preference { get; set; }
}

public record IncludesSubscriptionsParams : IncludesParams
{
    public bool? Year { get; set; }
    public bool? Teatcher { get; set; }
    public bool? Preference { get; set; }
}
