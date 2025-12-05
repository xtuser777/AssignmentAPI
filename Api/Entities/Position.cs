using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("cargo")]
[PrimaryKey(nameof(PositionId))]
public class Position : PositionProps
{
    public Position() 
    {
    }

    public Position(PositionProps props)
    {
        Assign(props);
    }

    public void Update(PositionProps props)
    {
        AssignUpdate(props);
    }
}

public class PositionProps : Entity
{
    [Column("idcargo")]
    public int? PositionId { get; set; }

    [Column("nome")]
    public string? Name { get; set; }

    [Column("ativo")]
    public char? Active { get; set; }
}
