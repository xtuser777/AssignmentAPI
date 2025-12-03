using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("Titles")]
public class Title: TitleProps
{
    public Title()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
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
    [Required]
    [StringLength(255)]
    public string? Description { get; set; }

    [Required]
    [StringLength(10)]
    public string? Alias { get; set; }

    [Required]
    [Column(TypeName = "decimal(12,3)")]
    public decimal? Weight { get; set; }

    [Required]
    [Column(TypeName = "decimal(12,3)")]
    public decimal? Max { get; set; }

    [Required]
    public int? Order { get; set; }

    [Required]
    public char? Type { get; set; }

    [Required]
    public bool? IsActive { get; set; }

    [Required]
    public int? YearId { get; set; }
}
