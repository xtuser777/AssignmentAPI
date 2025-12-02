using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("TitlesBySubscription")]
public class TitleBySubscription : TitleBySubscriptionProps
{
    public TitleBySubscription()
    {
        Id = Guid.NewGuid();
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
    public Guid? YearId { get; set; }

    [Required]
    public Guid? TeacherId { get; set; }

    [Required]
    public Guid? TitleId { get; set; }

    [Required]
    public Guid? SubscriptionId { get; set; }

    [Required]
    public decimal? Value { get; set; }

    [ForeignKey(nameof(YearId))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Year? Year { get; init; }

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
