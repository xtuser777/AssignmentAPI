using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("PointsBySubscriptions")]
public class PointsBySubscription : PointsBySubscriptionProps
{
    public PointsBySubscription()
    {
        Id = Guid.NewGuid();
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
    [Required]
    public Guid? YearId { get; set; }

    [Required]
    public Guid? SubscriptionId { get; set; }

    [Required]
    public int? Order { get; set; }

    [Required]
    [StringLength(255)]
    public string? Description { get; set; }

    [Required]
    public decimal? Points { get; set; }

    [ForeignKey(nameof(YearId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Year? Year { get; init; }

    [ForeignKey(nameof(SubscriptionId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Subscription? Subscription { get; init; }
}
