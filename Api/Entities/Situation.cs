using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("situacao")]
[PrimaryKey(nameof(SituationId))]
public class Situation : SituationProps
{
    public Situation()
    {
    }

    public Situation(SituationProps props)
    {
        Assign(props);
    }

    public void Update(SituationProps props)
    {
        AssignUpdate(props);
    }
}

public class SituationProps : Entity
{
    [Column("idsituacao")]
    public int? SituationId { get; set; }

    [Column("nome")]
    public string? Name { get; set; }
}
