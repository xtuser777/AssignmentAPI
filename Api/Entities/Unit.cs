using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("unidade")]
[PrimaryKey(nameof(UnitId))]
public class Unit : UnitProps
{
    public Unit()
    {
    }

    public Unit(UnitProps props)
    {
        Assign(props);
    }

    public void Update(UnitProps props)
    {
        AssignUpdate(props);
    }
}

public class UnitProps : Entity
{
    [Column("idunidade")]
    public int? UnitId { get; set; }

    [Column("nome")]
    public string? Name { get; set; }
}
