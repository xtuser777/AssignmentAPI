using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Api.Entities;

[Table("Classifications")]
public class Classification : ClassificationProps
{
    public Classification() 
    {
        Id = Guid.NewGuid();
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
    [ForeignKey(nameof(Year))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Guid? YearId { get; set; }
    [Required]
    [ForeignKey(nameof(Teatcher))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Guid? TeatcherId { get; set; }
    [Required]
    [ForeignKey(nameof(Subscription))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Guid? SubscriptionId { get; set; }
    [Required]
    [StringLength(200)]
    public string? Name { get; set; }
    [Required]
    [ForeignKey(nameof(Situation))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Guid? SituationId { get; set; }
    [Required]
    [StringLength(50)]
    public string? Situation { get; set; }
    [Required]
    [ForeignKey(nameof(Position))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Guid? PositionId { get; set; }
    [Required]
    [StringLength(50)]
    public string? Position { get; set; }
    [Required]
    [ForeignKey(nameof(Unit))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Guid? UnitId { get; set; }
    [Required]
    [StringLength(50)]
    public string? Unit { get; set; }
    [Required]
    [ForeignKey(nameof(Discipline))]
    [DeleteBehavior(DeleteBehavior.Restrict)]
    public Guid? DisciplineId { get; set; }
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
    public decimal? T1 { get; set; }
    public decimal? T2 { get; set; }
    public decimal? T3 { get; set; }
    public decimal? T4 { get; set; }
    public decimal? T5 { get; set; }
    public decimal? T6 { get; set; }
    public decimal? T7 { get; set; }
    public decimal? T8 { get; set; }
    public decimal? T9 { get; set; }
    public decimal? T10 { get; set; }
    public decimal? T11 { get; set; }
    public decimal? T12 { get; set; }
    public decimal? T13 { get; set; }
    public decimal? T14 { get; set; }
    public decimal? T15 { get; set; }
    public decimal? T16 { get; set; }
    public decimal? T17 { get; set; }
    public decimal? T18 { get; set; }
    public decimal? T19 { get; set; }
    public decimal? T20 { get; set; }
    public decimal? T21 { get; set; }
    public decimal? T22 { get; set; }
}
