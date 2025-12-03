using Assignment.Api.Entities;

namespace Assignment.Api.Interfaces.Repositories;

public interface IPointsBySubscriptionsRepository : IRepository<PointsBySubscription>
{
}

public class FindManyPointsBySubscriptionsParams : PointsBySubscriptionProps;

public class CountPointsBySubscriptionsParams : FindManyPointsBySubscriptionsParams;

public class ExistsPointsBySubscriptionsParams : CountPointsBySubscriptionsParams;

public class ExclusivePointsBySubscriptionsParams : CountPointsBySubscriptionsParams
{
    public int ExcludeId { get; set; }
}

public record OrderByPointsBySubscriptionsParams : OrderByParams
{
    public string? Year { get; set; }
    public string? Subscription { get; set; }
    public string? Order { get; set; }
    public string? Description { get; set; }
    public string? Points { get; set; }
}

public record IncludesPointsBySubscriptionsParams : IncludesParams
{
    public bool? Year { get; set; }
    public bool? Subscription { get; set; }
}
