using Assignment.Api.Entities;

namespace Assignment.Api.Interfaces.Repositories;

public interface ITitlesBySubscriptionsRepository : IRepository<TitleBySubscription>
{
}

public class FindManyTitleBySubscriptionsParams : TitleBySubscriptionProps;

public class CountTitleBySubscriptionsParams : FindManyTitleBySubscriptionsParams;

public class ExistsTitleBySubscriptionsParams : CountTitleBySubscriptionsParams;

public class ExclusiveTitleBySubscriptionsParams : CountTitleBySubscriptionsParams
{
    public Guid ExcludeId { get; set; }
}


public record OrderByTitlesBySubscriptionsParams : OrderByParams
{
    public string? Year { get; set; }
    public string? Teacher { get; set; }
    public string? Title { get; set; }
    public string? Subscription { get; set; }
    public string? Value { get; set; }
}

public record IncludesTitlesBySubscriptionsParams : IncludesParams
{
    public bool? Year { get; set; }
    public bool? Teacher { get; set; }
    public bool? Title { get; set; }
    public bool? Subscription { get; set; }
}
