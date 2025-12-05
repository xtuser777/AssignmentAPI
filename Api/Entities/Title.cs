using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("titulo")]
[PrimaryKey(nameof(YearId), nameof(TitleId))]
public class Title: TitleProps
{
    public Title()
    {
    }

    public Title(TitleProps props)
    {
        Assign(props);
    }

    public void Update(TitleProps props)
    {
        AssignUpdate(props);
    }
}

public class TitleProps : Entity
{
    [Column("idano")]
    public int? YearId { get; set; }

    [Column("idtitulo")]
    public int? TitleId { get; set; }

    [Column("descricao")]
    public string? Description { get; set; }

    [Column("sigla")]
    public string? Alias { get; set; }

    [Column("peso")]
    public decimal? Weight { get; set; }

    [Column("maximo")]
    public decimal? Max { get; set; }

    [Column("ordem")]
    public int? Order { get; set; }

    [Column("tipo")]
    public char? Type { get; set; }

    [Column("ativo")]
    public char? Active { get; set; }

    [ForeignKey(nameof(YearId))]
    public virtual Year? Year { get; set; }
}
