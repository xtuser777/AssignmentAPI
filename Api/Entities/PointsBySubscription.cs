using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

public class PointsBySubscription : PointsBySubscriptionProps
{
    public PointsBySubscription()
    {
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
    [Column("idano")]
    public int? YearId { get; set; }

    [Column("idinscricao")]
    public int? SubscriptionId { get; set; }

    [Column("ordem")]
    public int? Order { get; set; }

    [Column("descricao")]
    public string? Description { get; set; }

    [Column("pontos")]
    public decimal? Points { get; set; }
}
