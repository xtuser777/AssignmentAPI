using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

public class Classification : ClassificationProps
{
    public Classification() 
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Classification(ClassificationProps props)
    {
        Assign(props);
    }

    public void Update(ClassificationProps props)
    {
        AssignUpdate(props);
    }
}

public class ClassificationProps : Entity
{
    [Required]
    public int? YearId { get; set; }
    [Required]
    public int? Year {  get; set; }
    [Required]
    public int? TeacherId { get; set; }
    [Required]
    public int? SubscriptionId { get; set; }
    [Required]
    [StringLength(200)]
    public string? Name { get; set; }
    [Required]
    public int? SituationId { get; set; }
    [Required]
    [StringLength(50)]
    public string? Situation { get; set; }
    [Required]
    public int? PositionId { get; set; }
    [Required]
    [StringLength(50)]
    public string? Position { get; set; }
    [Required]
    public int? UnitId { get; set; }
    [Required]
    [StringLength(50)]
    public string? Unit { get; set; }
    [Required]
    public int? DisciplineId { get; set; }
    [Required]
    [StringLength(50)]
    public string? Discipline { get; set; }
    [Required]
    [StringLength(10)]
    public string? Phone { get; set; }
    [Required]
    [StringLength(11)]
    public string? Cellphone { get; set; }
    [StringLength(50)]
    public string? Speciality { get; set; }
    public bool? IsRemove { get; set; }
    public bool? IsAdido { get; set; }
    public bool? IsReadapted { get; set; }
    public bool? IsReadingRoom { get; set; }
    public bool? IsComputing { get; set; }
    public bool? IsSupplementCharge { get; set; }
    public bool? IsTutoring { get; set; }
    public bool? IsAmbientalEdication { get; set; }
    public bool? IsRobotics { get; set; }
    public bool? IsMusic { get; set; }

    [Column(TypeName = "decimal(12,3)")]
    public decimal? T1 { get; set; }

    [Column(TypeName = "decimal(12,3)")]
    public decimal? T2 { get; set; }

    [Column(TypeName = "decimal(12,3)")]
    public decimal? T3 { get; set; }

    [Column(TypeName = "decimal(12,3)")]
    public decimal? T4 { get; set; }

    [Column(TypeName = "decimal(12,3)")]
    public decimal? T5 { get; set; }

    [Column(TypeName = "decimal(12,3)")]
    public decimal? T6 { get; set; }

    [Column(TypeName = "decimal(12,3)")]
    public decimal? T7 { get; set; }

    [Column(TypeName = "decimal(12,3)")]
    public decimal? T8 { get; set; }

    [Column(TypeName = "decimal(12,3)")]
    public decimal? T9 { get; set; }

    [Column(TypeName = "decimal(12,3)")]
    public decimal? T10 { get; set; }

    [Column(TypeName = "decimal(12,3)")]
    public decimal? T11 { get; set; }

    [Column(TypeName = "decimal(12,3)")]
    public decimal? T12 { get; set; }

    [Column(TypeName = "decimal(12,3)")]
    public decimal? T13 { get; set; }

    [Column(TypeName = "decimal(12,3)")]
    public decimal? T14 { get; set; }

    [Column(TypeName = "decimal(12,3)")]
    public decimal? T15 { get; set; }

    [Column(TypeName = "decimal(12,3)")]
    public decimal? T16 { get; set; }

    [Column(TypeName = "decimal(12,3)")]
    public decimal? T17 { get; set; }

    [Column(TypeName = "decimal(12,3)")]
    public decimal? T18 { get; set; }

    [Column(TypeName = "decimal(12,3)")]
    public decimal? T19 { get; set; }

    [Column(TypeName = "decimal(12,3)")]
    public decimal? T20 { get; set; }

    [Column(TypeName = "decimal(12,3)")]
    public decimal? T21 { get; set; }

    [Column(TypeName = "decimal(12,3)")]
    public decimal? T22 { get; set; }
}
