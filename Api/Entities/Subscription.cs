using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("Subscriptions")]
public class Subscription : SubscriptionProps
{
    public Subscription() 
    {
        Id = Guid.NewGuid();
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
    [Required]
    [ForeignKey(nameof(Year))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Guid? YearId { get; set; }
    [Required]
    [ForeignKey(nameof(Teatcher))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Guid? TeatcherId { get; set; }
    [Required]
    [ForeignKey(nameof(Preference))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Guid? PreferenceId { get; set; }
}
