namespace Assignment.Api.Entities;

public class TitleBySubscription : TitleBySubscriptionProps
{
    public TitleBySubscription()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public TitleBySubscription(TitleBySubscriptionProps props)
    {
        Assign(props);
    }

    public void Update(TitleBySubscriptionProps props)
    {
        AssignUpdate(props);
    }
}

public class TitleBySubscriptionProps : Entity
{
    public int? YearId { get; set; }
    public int? TeacherId { get; set; }
    public int? TitleId { get; set; }
    public int? SubscriptionId { get; set; }
    public decimal? Value { get; set; }
    public Year? Year { get; set; }
    public Teacher? Teacher { get; init; }
    public Title? Title { get; init; }
    public Subscription? Subscription { get; init; }
}
