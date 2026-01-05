using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("titulo_por_inscricao")]
[PrimaryKey(nameof(SubscriptionId), nameof(TitleId), nameof(YearId), nameof(TeacherId))]
public class TitleBySubscription : TitleBySubscriptionProps
{
    public TitleBySubscription()
    {
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
    [Column("idinscricao")]
    public int? SubscriptionId { get; set; }

    [Column("idano")]
    public int? YearId { get; set; }

    [Column("idprofessor")]
    public int? TeacherId { get; set; }

    [Column("idtitulo")]
    public int? TitleId { get; set; }

    [Column("valor")]
    public decimal? Value { get; set; }

    [ForeignKey(nameof(YearId))]
    public virtual Year? Year { get; set; }

    [ForeignKey($"{nameof(YearId)}, {nameof(TeacherId)}")]
    public virtual Teacher? Teacher { get; init; }

    [ForeignKey($"{nameof(YearId)}, {nameof(TitleId)}")]
    public virtual Title? Title { get; init; }

    [ForeignKey($"{nameof(SubscriptionId)}, {nameof(YearId)}, {nameof(TeacherId)}")]
    public virtual Subscription? Subscription { get; init; }
}
