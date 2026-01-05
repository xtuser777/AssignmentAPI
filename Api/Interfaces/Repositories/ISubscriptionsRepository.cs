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
    public string? YearId { get; set; }
    public string? Teacher { get; set; }
    public string? Preference { get; set; }
}

public record IncludesSubscriptionsTeacherParams
{
    public bool? Unit { get; set; }
}

public record IncludesSubscriptionsParams : IncludesParams
{
    public IncludesSubscriptionsTeacherParams? Teacher { get; set; }
    public bool? Preference { get; set; }
    public bool? Titles { get; set; }
    public bool? Points { get; set; }
}
