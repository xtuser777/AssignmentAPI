using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("disciplina")]
[PrimaryKey(nameof(DisciplineId))]
public class Discipline : DisciplineProps
{
    public Discipline()
    {
    }

    public Discipline(DisciplineProps props)
    {
        Assign(props);
    }

    public void Update(DisciplineProps props)
    {
        AssignUpdate(props);
    }
}

public class DisciplineProps : Entity
{
    [Column("iddisciplina")]
    public int? DisciplineId { get; set; }

    [Column("nome")]
    public string? Name { get; set; }
}
