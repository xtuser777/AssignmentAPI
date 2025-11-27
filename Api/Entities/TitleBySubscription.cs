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
    [ForeignKey(nameof(Year))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Guid? YearId { get; set; }
    [Required]
    [ForeignKey(nameof(Teatcher))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Guid? TeatcherId { get; set; }
    [Required]
    [ForeignKey(nameof(Title))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Guid? TitleId { get; set; }
    [Required]
    [ForeignKey(nameof(Subscription))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Guid? SubscriptionId { get; set; }
    [Required]
    public decimal? Value { get; set; }
}
