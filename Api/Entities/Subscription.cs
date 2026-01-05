using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("inscricao")]
[PrimaryKey(nameof(SubscriptionId), nameof(YearId), nameof(TeacherId))]
public class Subscription : SubscriptionProps
{
    public Subscription() 
    {
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
    [Column("idinscricao")]
    public int? SubscriptionId { get; set; }

    [Column("idano")]
    public int? YearId { get; set; }

    [Column("idprofessor")]
    public int? TeacherId { get; set; }

    [Column("idpreferencia")]
    public int? PreferenceId { get; set; }

    [ForeignKey(nameof(YearId))]
    public virtual Year? Year { get; set; }

    [ForeignKey($"{nameof(YearId)}, {nameof(TeacherId)}")]
    public virtual Teacher? Teacher { get; set; }

    [ForeignKey(nameof(PreferenceId))]
    public virtual Preference? Preference { get; set; }

    [InverseProperty("Subscription")]
    public virtual ICollection<TitleBySubscription>? Titles { get; set; }

    [NotMapped]
    public virtual ICollection<PointsBySubscription>? Points { get; set; }
}
