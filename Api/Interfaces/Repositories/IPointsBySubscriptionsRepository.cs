using Assignment.Api.Entities;

namespace Assignment.Api.Interfaces.Repositories;

public interface IPointsBySubscriptionsRepository : IRepository<PointsBySubscription>
{
}

public class FindManyPointsBySubscriptionsParams : PointsBySubscriptionProps;

public class CountPointsBySubscriptionsParams : FindManyPointsBySubscriptionsParams;

public class ExistsPointsBySubscriptionsParams : CountPointsBySubscriptionsParams;

public record OrderByPointsBySubscriptionsParams : OrderByParams
{
    public string? YearId { get; set; }
    public string? SubscriptionId { get; set; }
    public string? Order { get; set; }
    public string? Description { get; set; }
    public string? Points { get; set; }
}
