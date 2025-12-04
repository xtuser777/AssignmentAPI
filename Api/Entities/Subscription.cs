namespace Assignment.Api.Entities;

public class Subscription : SubscriptionProps
{
    public Subscription() 
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Subscription(SubscriptionProps props)
    {
        Assign(props);
    }

    public void Update(SubscriptionProps props)
    {
        AssignUpdate(props);
    }
}

public class SubscriptionProps : Entity
{
    public int? YearId { get; set; }
    public int? TeacherId { get; set; }
    public int? PreferenceId { get; set; }
    public Year? Year { get; set; }
    public Teacher? Teacher { get; set; }
    public Preference? Preference { get; set; }
    public IEnumerable<TitleBySubscription>? Titles { get; set; }
    public IEnumerable<PointsBySubscription>? Points { get; set; }
}
