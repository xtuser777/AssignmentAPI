using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("ano")]
[PrimaryKey(nameof(YearId))]
public class Year : YearProps
{
    public Year()
    {
    }

    public Year(YearProps props)
    {
        Assign(props);
    }

    public void Update(YearProps props)
    {
        AssignUpdate(props);
    }
}

public class YearProps : Entity
{
    [Column("idano")]
    public int? YearId { get; set; }

    [Column("ficha")]
    public string? Record { get; set; }

    [Column("resolucao")]
    public string? Resolution { get; set; }

    [Column("bloqueado")]
    public char? IsBlocked { get; set; }
}
