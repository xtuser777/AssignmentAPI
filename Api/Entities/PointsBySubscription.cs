namespace Assignment.Api.Entities;

public class PointsBySubscription : PointsBySubscriptionProps
{
    public PointsBySubscription()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public PointsBySubscription(PointsBySubscriptionProps props)
    {
        Assign(props);
    }

    public void Update(PointsBySubscriptionProps props)
    {
        AssignUpdate(props);
    }
}

public class PointsBySubscriptionProps : Entity
{
    public int? YearId { get; set; }
    public int? SubscriptionId { get; set; }
    public int? Order { get; set; }
    public string? Description { get; set; }
    public decimal? Points { get; set; }
    public Year? Year { get; init; }
    public Subscription? Subscription { get; init; }
}
