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
    public Guid? YearId { get; set; }

    [Required]
    public Guid? TeatcherId { get; set; }

    [Required]
    public Guid? PreferenceId { get; set; }

    [ForeignKey(nameof(YearId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Year? Year { get; set; }
    
    [ForeignKey(nameof(TeatcherId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Teatcher? Teatcher { get; set; }
    
    [ForeignKey(nameof(PreferenceId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Preference? Preference { get; set; }
}
