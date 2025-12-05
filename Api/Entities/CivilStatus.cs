using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("estado_civil")]
[PrimaryKey(nameof(CivilStatusId))]
public class CivilStatus : CivilStatusProps
{
    public CivilStatus()
    {
    }

    public CivilStatus(CivilStatusProps props)
    {
        Assign(props);
    }

    public void Update(CivilStatusProps props)
    {
        AssignUpdate(props);
    }
}

public class CivilStatusProps : Entity
{
    [Column("idestado_civil")]
    public int? CivilStatusId { get; set; }

    [Column("nome")]
    public string? Name { get; set; }
}
