using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("TitlesBySubscription")]
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
    [Required]
    public int? YearId { get; set; }

    [Required]
    public int? TeacherId { get; set; }

    [Required]
    public int? TitleId { get; set; }

    [Required]
    public int? SubscriptionId { get; set; }

    [Required]
    [Column(TypeName = "decimal(12,3)")]
    public decimal? Value { get; set; }

    [ForeignKey(nameof(TeacherId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Teacher? Teacher { get; init; }

    [ForeignKey(nameof(TitleId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Title? Title { get; init; }

    [ForeignKey(nameof(SubscriptionId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Subscription? Subscription { get; init; }
}
