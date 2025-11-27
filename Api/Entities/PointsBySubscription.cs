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
    [ForeignKey(nameof(Year))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Guid? YearId { get; set; }

    [Required]
    [ForeignKey(nameof(Subscription))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Guid? SubscriptionId { get; set; }

    [Required]
    public int? Order { get; set; }

    [Required]
    [StringLength(255)]
    public string? Description { get; set; }

    [Required]
    public decimal? Points { get; set; }
}
